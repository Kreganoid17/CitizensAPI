using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface CitizenInterface
    {

        Task<ActionResult<List<Citizen>>> Get();

        Task<ActionResult<Citizen>> Get(int id);

        Task<ActionResult<List<Citizen>>> AddCitizen(Citizen citizen);

        Task<ActionResult<List<Citizen>>> UpdateCitizen(Citizen request);

        Task<ActionResult<List<Citizen>>> DeleteCitizen(int id);

    }
}
