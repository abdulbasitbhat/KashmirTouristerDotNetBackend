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
        public IActionResult updateBlog(Guid id, UpdateCertificateRequestDTO request )
        {
            var req = dbContext.CertificateRequest.Find(id);
            if (req is null)
            {
                return NotFound();
            }
            req.email = request.email;
            req.landmark = request.landmark;
            req.image = request.image;
            req.hallOfTravellers = request.hallOfTravellers;
            req.issueStatus = request.issueStatus;

            dbContext.SaveChanges();
            return Ok(req);

        }

    }
}
