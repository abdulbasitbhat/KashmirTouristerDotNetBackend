using KashmiriTourister.Data;
using KashmiriTourister.Models;
using KashmiriTourister.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace KashmiriTourister.Controllers
{
    //localhost:xxx/api/landmarks    [controller] auto maps to LandmarksController Landmarks keyword
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public LandmarksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("allLandmarks")]
        public IActionResult GetAllLandmarks()
        {
            var allLandmarks = dbContext.Landmarkss.ToList();
            return Ok(allLandmarks);
        }

        [HttpGet]
        [Route("id/{id:guid}")]
        public IActionResult GetLandmarkById(Guid id)
        {
            var Landmark = dbContext.Landmarkss.Find(id);
            if(Landmark is null)
            {
                return NotFound();
            }
            return Ok(Landmark);

        }

        [HttpPost]
        [Route("addLandmark")]
        public IActionResult AddLandmark(AddLandmarkDTO addLandmarkDTO)
        {
            var LandmarkEntity = new Landmarks()
            {
                landmark = addLandmarkDTO.landmark,
                location = addLandmarkDTO.location,
                type = addLandmarkDTO.type,
                properties = addLandmarkDTO.properties,
                image = addLandmarkDTO.image,
                iframesrc = addLandmarkDTO.iframesrc,
                highlights = addLandmarkDTO.highlights,
                about =addLandmarkDTO.about,
                best_time_to_visit = addLandmarkDTO.best_time_to_visit

            };

            dbContext.Landmarkss.Add(LandmarkEntity);
            dbContext.SaveChanges();
            return Ok(LandmarkEntity);
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        public IActionResult UpdateLandmark(Guid id, UpdateLandmarkDTO updateLandmarkDTO)
        {
            var Landmark = dbContext.Landmarkss.Find(id);
            if(Landmark is null)
            {
                return NotFound();
            }
            Landmark.landmark = updateLandmarkDTO.landmark;
            Landmark.location=updateLandmarkDTO.location;
            Landmark.type = updateLandmarkDTO.type;
            Landmark.properties = updateLandmarkDTO.properties;
            Landmark.image = updateLandmarkDTO.image;
            Landmark.iframesrc = updateLandmarkDTO.iframesrc;
            Landmark.highlights = updateLandmarkDTO.highlights;
            Landmark.about = updateLandmarkDTO.about;
            Landmark.best_time_to_visit = updateLandmarkDTO.best_time_to_visit;



            dbContext.SaveChanges();
            return Ok(Landmark);

        }

        [HttpDelete]
        [Route("delete/{id:Guid}")]
        public IActionResult DeleteLandmark(Guid id)
        {
            var Landmark = dbContext.Landmarkss.Find(id);
            if (Landmark is null)
            {
                return NotFound();
            }
            dbContext.Landmarkss.Remove(Landmark);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
