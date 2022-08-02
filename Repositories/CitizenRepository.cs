using API.Interfaces;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CitizenRepository : CitizenInterface
    {
        private readonly DataContext _context;

        public CitizenRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Citizen>>> AddCitizen(Citizen citizen)
        {
            _context.citizens.Add(citizen);

            await _context.SaveChangesAsync();

            return (await _context.citizens.ToListAsync());
        }

        public async Task<ActionResult<List<Citizen>>> DeleteCitizen(int id)
        {
            var citizen = await _context.citizens.FindAsync(id);

            try
            {

                if (citizen == null)
                {

                    throw new Exception("Citizen Not Found"); 

                }
                else
                {

                    _context.citizens.Remove(citizen);
                    await _context.SaveChangesAsync();

                    return (await _context.citizens.ToListAsync());


                }

            }
            catch (Exception ex)
            {

                throw ex;

            }

            
        }


        public async Task<ActionResult<List<Citizen>>> Get()
        {
            return (await _context.citizens.ToListAsync());
        }

        public async Task<ActionResult<Citizen>> Get(int id)
        {
            var citizen = await _context.citizens.FindAsync(id);

            try
            {

                if (citizen == null)
                {

                    throw new Exception("Citizen Not Found");

                }
                else
                {

                    return (citizen);

                }

            }
            catch (Exception ex) {

                throw ex;
            
            }

        }

        public async Task<ActionResult<List<Citizen>>> UpdateCitizen(Citizen request)
        {
            var citizen = await _context.citizens.FindAsync(request.ID);

            try
            {

                if (citizen == null)
                {

                    return null;

                }
                else
                {

                    citizen.FirstName = request.FirstName;
                    citizen.LastName = request.LastName;
                    citizen.Country = request.Country;

                    await _context.SaveChangesAsync();

                    return (await _context.citizens.ToListAsync());

                }

            }
            catch (Exception ex) { 
            
                throw ex;
            
            }

            

            
        }
    }
}
