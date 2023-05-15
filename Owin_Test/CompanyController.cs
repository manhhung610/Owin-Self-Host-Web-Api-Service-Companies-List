using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Owin_Test
{
	public class CompanyController:ApiController
	{
		private List<Company> companiesList;
		public CompanyController()
		{
			companiesList = new List<Company>()
			{
				new Company {Name = "Apple", Nation = "US", YearFounded = 1977},
				new Company {Name = "Nokia", Nation = "Finland", YearFounded = 1865},
				new Company {Name = "Samsung", Nation = "Korea", YearFounded = 1938}
			};
		}
		public IHttpActionResult Get() {
			return Ok(companiesList); //ham Ok la tra ve HTTP Code
		}
		public Company Get(int id) {	//vi de khong cho id company nen lam 2 TH 1 la co id 2 la ko tim dc id
			try
			{
				return companiesList[id];
			}
			catch (Exception ex)
			{
				return new Company();
			}
		}
		public void Post(Company item) {
			companiesList.Add(item);
				}
		public void Put(int id, Company item) {
			Company selectedCompany = companiesList[id];
			selectedCompany.Name = string.IsNullOrEmpty(item.Name) ? item.Name : selectedCompany.Name;
			selectedCompany.Nation = string.IsNullOrEmpty(item.Nation) ? item.Nation : selectedCompany.Nation;
			selectedCompany.YearFounded = item.YearFounded > 0 ? item.YearFounded : selectedCompany.YearFounded;
		}
		public void Delete(int id) {
			Company selectedCompany = companiesList[id];
			companiesList.Remove(selectedCompany);
		}
	}
}
