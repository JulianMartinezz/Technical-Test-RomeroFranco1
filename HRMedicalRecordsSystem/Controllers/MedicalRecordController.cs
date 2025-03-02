using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Responses;
using HRMedicalRecordsSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HRMedicalRecordsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IServiceHRMedicalRecords _medicalService;

        public MedicalRecordController(IServiceHRMedicalRecords service)
        {
            _medicalService = service;
        }


        [HttpGet("GetRecordByID")]

        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> GetMedicalRecordByID([FromQuery]int id)
        {
            return Ok( await _medicalService.GetMedicalRecordByID(id));
        }



        [HttpPost("PostRecord")]

        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> PostMedicalRecord([FromBody] MedicalPostDTO postDTO)
        {
            return Ok(await _medicalService.AddMedicalRecord(postDTO));
        }


        [HttpPut("PutRecord")]

        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> PutMedicalRecord([FromBody]MedicalUpdateDTO updateDTO) 
        {
            return Ok( await _medicalService.UpdateMedicalRecord(updateDTO));
        }


        [HttpDelete("DeleteRecord")]


        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> DeleteMedicalRecord([FromBody]MedicalDeleteDTO deleteDTO) 
        {
            return Ok( await _medicalService.DeleteMedicalRecord(deleteDTO));
        }

        [HttpGet("GetFilterMedicalRecords")]

        public async Task<ActionResult<BaseResponse<List<TMedicalRecord>>>> GetFilteredMedicalRecords([FromQuery]MedicalGetDTO GetFiltros) 
        {
            return Ok(await _medicalService.GetFilterMedicalRecords(GetFiltros));
        }



    }
}
