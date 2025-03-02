using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Responses;
using HRMedicalRecordsSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HRMedicalRecordsSystem.Controllers
{
    /// <summary>
    /// Controller to manage medical records.
    /// Provides API endpoints for retrieving, adding, updating, and deleting medical records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IServiceHRMedicalRecords _medicalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalRecordController"/> class.
        /// </summary>
        /// <param name="service">Service to handle medical record operations.</param>
        public MedicalRecordController(IServiceHRMedicalRecords service)
        {
            _medicalService = service;
        }


        /// <summary>
        /// Retrieves a medical record by its ID.
        /// </summary>
        /// <param name="id">The ID of the medical record.</param>
        /// <returns>A response with the requested medical record.</returns>
        [HttpGet("GetRecordByID")]

        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> GetMedicalRecordByID([FromQuery]int id)
        {
            return Ok( await _medicalService.GetMedicalRecordByID(id));
        }


        /// <summary>
        /// Adds a new medical record.
        /// </summary>
        /// <param name="postDTO">Data transfer object containing the medical record information to be added.</param>
        /// <returns>A response with the newly added medical record.</returns>
        [HttpPost("PostRecord")]

        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> PostMedicalRecord([FromBody] MedicalPostDTO postDTO)
        {
            return Ok(await _medicalService.AddMedicalRecord(postDTO));
        }

        /// <summary>
        /// Updates an existing medical record.
        /// </summary>
        /// <param name="updateDTO">Data transfer object containing the medical record information to be updated.</param>
        /// <returns>A response with the updated medical record.</returns>
        [HttpPut("PutRecord")]

        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> PutMedicalRecord([FromBody]MedicalUpdateDTO updateDTO) 
        {
            return Ok( await _medicalService.UpdateMedicalRecord(updateDTO));
        }


        /// <summary>
        /// Deletes an existing medical record.
        /// </summary>
        /// <param name="deleteDTO">Data transfer object containing the information to identify the medical record to be deleted.</param>
        /// <returns>A response confirming the deletion of the medical record.</returns>
        [HttpDelete("DeleteRecord")]


        public async Task<ActionResult<BaseResponse<TMedicalRecord>>> DeleteMedicalRecord([FromBody]MedicalDeleteDTO deleteDTO) 
        {
            return Ok( await _medicalService.DeleteMedicalRecord(deleteDTO));
        }

        /// <summary>
        /// Retrieves a filtered list of medical records based on specified filters.
        /// </summary>
        /// <param name="GetFiltros">DTO containing the filtering parameters for retrieving the medical records.</param>
        /// <returns>A response with the filtered list of medical records.</returns>
        [HttpGet("GetFilterMedicalRecords")]

        public async Task<ActionResult<BaseResponse<List<TMedicalRecord>>>> GetFilteredMedicalRecords([FromQuery]MedicalGetDTO GetFiltros) 
        {
            return Ok(await _medicalService.GetFilterMedicalRecords(GetFiltros));
        }



    }
}
