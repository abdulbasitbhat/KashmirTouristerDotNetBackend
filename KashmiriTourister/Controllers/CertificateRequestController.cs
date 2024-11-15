using Azure.Core;
using KashmiriTourister.Data;
using KashmiriTourister.Models;
using KashmiriTourister.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;

namespace KashmiriTourister.Controllers
{
    [Route("api/certify/[controller]")]
    [ApiController]
    public class CertificateRequestController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CertificateRequestController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("addRequest")]
        public IActionResult AddRequest(AddCertifateRequestDTO request)
        {
            var cRequest = new CertificateRequest()
            {
                email = request.email,
                landmark = request.landmark,
                landmarkId = request.landmarkId,
                image = request.image,
                hallOfTravellers = request.hallOfTravellers,
                issueStatus = request.issueStatus
            };
            dbContext.CertificateRequest.Add(cRequest);
            dbContext.SaveChanges();
            return Ok(cRequest);
        }

        [HttpGet]
        [Route("allRequests")]
        public IActionResult allRequests()
        {
            var requests = dbContext.CertificateRequest.ToList();   
            return Ok(requests);
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        public IActionResult updateRequest(Guid id, UpdateCertificateRequestDTO request)
        {
            var req = dbContext.CertificateRequest.Find(id);
            if (req is null)
            {
                return NotFound();
            }

            if (request.email != "")
            {
                req.email = request.email;
            }

            if (request.landmark != "")
            {
                req.landmark = request.landmark;
            }

            if (request.landmarkId != "")
            {
                req.landmarkId = request.landmarkId;
            }

            if (request.image != "")
            {
                req.image = request.image;
            }

            req.hallOfTravellers = request.hallOfTravellers;

            req.issueStatus = request.issueStatus; // Assuming issueStatus is a boolean and can be updated directly

            dbContext.SaveChanges();
            return Ok(req);
        }

        [HttpPut]
        [Route("id/{id:guid}")]
        public IActionResult getRequestById(Guid id, UpdateCertificateRequestDTO request)
        {
            var req = dbContext.CertificateRequest.Find(id);
            if (req is null)
            {
                return NotFound();
            }
            return Ok(req);
        }

        [HttpDelete]
        [Route("delete/{id:guid}")]
        public IActionResult delRequest(Guid id)
        {
            var req = dbContext.CertificateRequest.Find(id);
            if (req is null)
            {
                return NotFound();
            }
            dbContext.CertificateRequest.Remove(req);
            dbContext.SaveChanges();
            return Ok(req);
        }

    }
}
