using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarHistoryAPI.Model;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarHistoryAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MileageController : ControllerBase
{
    FirebaseConfig config = new FirebaseConfig
    {
        AuthSecret = "CuKCgdTK2064ldnBMGqwd59AbiAzoIqg3rKvFPCP",
        BasePath = "https://duombazeskitas-default-rtdb.europe-west1.firebasedatabase.app/"
    };
    FirebaseClient client;


    // GET api/reaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MileageModel>>> GetMileageList()
    {
        client = new FirebaseClient(config);
        var response = await client.GetAsync("Mileage");
        dynamic jResult = JsonConvert.DeserializeObject(response.Body);
        var list = new List<MileageModel>();
        foreach (var item in jResult)
        {
            list.Add(JsonConvert.DeserializeObject<MileageModel>(((JProperty)item).Value.ToString()));
        }

        return Ok(list);
    }
    
    // GET api/reaction/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<MileageModel>> GetMileageById([FromRoute] Guid id)
    {
        //var reactionFromRepo = null;
        //if (reactionFromRepo is null)
        //{
        //    return NotFound();
        //}
        //return Ok(reactionFromRepo);
        return Ok();
    }
    // POST api/reaction
    [HttpPost]
    public async Task<ActionResult> CreateMileage([FromBody] MileageModel request)
    {
        InsertData(request);
        return NoContent();
    }
    // PUT api/reaction
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateMileage([FromRoute] Guid id, [FromBody] MileageModel request)
    {
        return NoContent();
    }
    // Delete api/reaction/{id}
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteMileageById([FromRoute] Guid id)
    {

        return NoContent();
    }

    private void InsertData(MileageModel mileage)
    {
        client = new FirebaseClient(config);
        //_ = client.Push("Mileage/", mileage);
        client.PushAsync("Mileage/", mileage);
    }
}
