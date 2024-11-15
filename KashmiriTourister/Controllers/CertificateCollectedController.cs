using KashmiriTourister.Data;
using KashmiriTourister.Models;
using KashmiriTourister.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KashmiriTourister.Controllers
{
    [Route("/api/certificateCollected")]
    [ApiController]
    public class CertificateCollectedController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CertificateCollectedController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("allCertificates")]
        public IActionResult allCert()
        {
            var requests = dbContext.CertificateCollected.ToList();
            return Ok(requests);
        }

        [HttpGet]
        [Route("id/{id:guid}")]
        public IActionResult getCertificate(Guid id)
        {
            var cert = dbContext.CertificateCollected.Find(id);

            if(cert is null)
            {
                return NotFound();
            }
            return Ok(cert);
        }

        [HttpPost]
        [Route("addCert")]
        public IActionResult AddCert(AddCertificateCollectedDTO request)
        {
            var cRequest = new CertificateCollected()
            {
                email = request.email,
                cardId = request.cardId,
                Image = request.Image
            };
            dbContext.CertificateCollected.Add(cRequest);
            dbContext.SaveChanges();
            return Ok(cRequest);
        }

        [HttpDelete]
        [Route("delete/{id:guid}")]
        public IActionResult delCert(Guid id)
        {
            var req = dbContext.CertificateCollected.Find(id);
            if (req is null)
            {
                return NotFound();
            }
            dbContext.CertificateCollected.Remove(req);
            dbContext.SaveChanges();
            return Ok(req);
        }
    }
}
