using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using acscustomersgatebackend.Models;
using acscustomersgatebackend.Models.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Authorize]
[Route("[controller]/[action]")]
[EnableCors("AllowAnyOrigin")]
public class RFQController : Controller
{
    CustomersGateContext _context;

    public RFQController(CustomersGateContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    public string test()
    {
        return "API is working...";
    }

    #region RFQs
    // GET RFQ/Get
    [HttpGet]
    public IEnumerable<RFQ> Get()
    {
        return _context.RFQs.ToList();
    }

    // GET RFQ/Get/5
    [HttpGet("{id}", Name = "GetRFQ")]
    public ActionResult Get(int id)
    {
        var item = _context.RFQs.SingleOrDefault(o => o.RFQId == id);
        if (item == null)
        {
            return NotFound();
        }

        return new ObjectResult(item);
    }

    // POST RFQ/Post
    [HttpPost]
    [AllowAnonymous]
    public ActionResult Post([FromBody]RFQ rfq)
    {
        if (rfq == null)
        {
           return BadRequest();
        }

        bool saved = false;

        try
        {
            rfq.RFQCode = DateTime.Now.Ticks.ToString();
            rfq.SubmissionTime = DateTime.Now;

            _context.RFQs.Add(rfq);
            _context.SaveChanges();
            saved = true;
        }
        catch (System.Exception)
        {
            saved = false;
            throw;
        }

        if (!saved)
            return new NoContentResult();

        if (rfq.SendEmail)
        {
            bool sent = false;
            try
            {
                MailHelper.sendMail(new MailData
                {
                    Message = new MailMessageData(new[] { rfq.ContactPersonEmail })
                    {
                        Body = MailHelper.MessageBody(rfq.ContactPersonEnglishName, rfq.ContactPersonMobile)
                    },
                    SMTP = new SmtpData()
                });
                sent = true;
            }
            catch (Exception ex)
            {
                sent = false;
                throw ex;
            }

            if (sent)
            {
                RFQAction rfqAction = new RFQAction
                {
                    ActionCode = DateTime.Now.Ticks.ToString(),
                    ActionTime = DateTime.Now,
                    ActionType = ActionType.EmailMessage,
                    Comments = "Automated Email",
                    RepresentativeId = 0,
                    SubmissionTime = DateTime.Now,
                    UniversalIP = rfq.UniversalIP
                };
                var newRfq = _context.RFQs.Where(r => r.RFQId == rfq.RFQId).Include(r => r.RFQActions).SingleOrDefault();
                newRfq.RFQActions.Add(rfqAction);
                _context.SaveChanges();
            }
        }
        
        return new NoContentResult();
    }

    // PUT RFQ/Put/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody]RFQ rfq)
    {
        if (rfq == null || rfq.RFQId != id)
        {
            return BadRequest();
        }

        var orgItem = _context.RFQs.SingleOrDefault(o => o.RFQId == id);
        if (orgItem == null)
        {
            return NotFound();
        }

        orgItem.Address = rfq.Address;
        orgItem.CompanyArabicName = rfq.CompanyArabicName;
        orgItem.CompanyEnglishName = rfq.CompanyEnglishName;
        orgItem.ContactPersonArabicName = rfq.ContactPersonArabicName;
        orgItem.ContactPersonEmail = rfq.ContactPersonEmail;
        orgItem.ContactPersonEnglishName = rfq.ContactPersonEnglishName;
        orgItem.ContactPersonMobile = rfq.ContactPersonMobile;
        orgItem.ContactPersonPosition = rfq.ContactPersonPosition;
        orgItem.Location = rfq.Location;
        orgItem.PhoneNumber = rfq.PhoneNumber;
        orgItem.SelectedBundle = rfq.SelectedBundle;
        orgItem.Status = rfq.Status;
        orgItem.SubmissionTime = DateTime.Now;
        orgItem.TargetedProduct = rfq.TargetedProduct;
        orgItem.UniversalIP = rfq.UniversalIP;
        orgItem.Website = rfq.Website;

        _context.RFQs.Update(orgItem);
        _context.SaveChanges();

        return new ObjectResult(orgItem);
    }

    // DELETE RFQ/Delete/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var item = _context.RFQs.SingleOrDefault(o => o.RFQId == id);
        if (item == null)
        {
            return NotFound();
        }

        _context.RFQs.Remove(item);
        _context.SaveChanges();

        return new NoContentResult();
    }
    #endregion

    #region Actions
    // GET RFQ/Status/5
    [HttpGet("{id}", Name = "GetRFQStatus")]
    public async Task<ActionResult> Status(int id)
    {
        var item = _context.RFQs
            .Where(o => o.RFQId == id)
            .Include(r => r.RFQActions)
            .ThenInclude(a => a.Representative)
            .FirstOrDefault();

        if (item == null)
        {
            return NotFound();
        }

        var rfqAction = item.RFQActions
            .Select(a =>
            {
                return new
                {
                    a.ActionCode,
                    a.ActionTime,
                    a.ActionType,
                    a.Comments,
                    Representative = new {
                        a.Representative.Address,
                        a.Representative.Continuous,
                        a.Representative.Created,
                        a.Representative.DateOfBirth,
                        a.Representative.Id,
                        a.Representative.Name,
                        a.Representative.PersonalPhone,
                        a.Representative.Phone,
                        a.Representative.Position,
                        a.Representative.UniversalIP
                    },
                    a.Id,
                    a.RFQId,
                    a.SubmissionTime,
                    a.UniversalIP
                };
            }).SingleOrDefault(a => a.ActionTime == item.RFQActions.Max(a1 => a1.ActionTime));

        return await Task.Run(() => new ObjectResult(rfqAction));
    }

    // GET RFQ/Actions/5
    [HttpGet("{id}", Name = "GetRFQActions")]
    public async Task<IEnumerable<Object>> Actions(int id)
    {
        var item = _context.RFQs
            .Where(o => o.RFQId == id)
            .Include(r => r.RFQActions)
            .ThenInclude(a => a.Representative)
            .FirstOrDefault();

        if (item == null)
        {
            return null;
        }

        var rfqActions = item.RFQActions
            .Select(a =>
            {
                return new
                {
                    a.ActionCode,
                    a.ActionTime,
                    a.ActionType,
                    a.Comments,
                    Representative = new {
                        a.Representative.Address,
                        a.Representative.Continuous,
                        a.Representative.Created,
                        a.Representative.DateOfBirth,
                        a.Representative.Id,
                        a.Representative.Name,
                        a.Representative.PersonalPhone,
                        a.Representative.Phone,
                        a.Representative.Position,
                        a.Representative.UniversalIP
                    },
                    a.Id,
                    a.RFQId,
                    a.SubmissionTime,
                    a.UniversalIP
                };
            });

        return await Task.Run(() => rfqActions);
    }

    // POST RFQ/AddStatus/5
    [HttpPost("{id}", Name = "AddRFQAction")]
    public async Task<ActionResult> AddStatus(int id, [FromBody]RFQAction action)
    {
        var item = _context.RFQs.Where(o => o.RFQId == id).Include(r => r.RFQActions).FirstOrDefault();

        if (item == null)
        {
            return NotFound();
        }

        action.ActionCode = DateTime.Now.Ticks.ToString();
        action.ActionTime = DateTime.Now;
        action.SubmissionTime = DateTime.Now;

        item.RFQActions.Add(action);
        _context.SaveChanges();

        return await Task.Run(() => new NoContentResult());
    }

    // POST RFQ/UpdateStatus/5/1
    [HttpPost("{id}/{actionId}", Name = "UpdateRFQAction")]
    public async Task<ActionResult> UpdateStatus(int id, int actionId, [FromBody]RFQAction action)
    {
        var item = _context.RFQs.Where(o => o.RFQId == id).Include(r => r.RFQActions).FirstOrDefault();

        if (item == null)
        {
            return NotFound();
        }

        var orgAction = item.RFQActions.Where(a => a.Id == actionId).FirstOrDefault();

        if (orgAction == null)
        {
            return NotFound();
        }

        orgAction.ActionType = action.ActionType;
        orgAction.RepresentativeId = action.RepresentativeId;
        orgAction.Comments = action.Comments;
        orgAction.UniversalIP = action.UniversalIP;

        orgAction.SubmissionTime = DateTime.Now;

        _context.SaveChanges();

        return await Task.Run(() => new NoContentResult());
    }
    #endregion
}