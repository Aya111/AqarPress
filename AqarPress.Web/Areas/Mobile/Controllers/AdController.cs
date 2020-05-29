using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using AqarPress.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imager = AqarPress.Web.Areas.Mobile.Controllers.MediaController;

namespace AqarPress.Web.Areas.Mobile.Controllers
{
    [Route("api/1/Ad")]
    [ApiController]
    [TypeFilter(typeof(RequireAPISession))]
    public class AdController : ControllerBase
    {
        public AdRepository _adRepository;

        public AdController(AdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ad>>> GetAll()
        {
            var result = await _adRepository.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            var reply = result.Select(r => new Ad(r, t => Imager.GenerateAdImageUrl(Request, r.Path)));

            return Ok(reply);
        }
    }
}
