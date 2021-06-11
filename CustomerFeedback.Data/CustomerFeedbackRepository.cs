using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomerFeedback.Data
{
    public class CustomerFeedbackRepository : ICustomerFeedbackRepository
    {
        private readonly ICustomerFeedbackRepository _customerFeedbackRepository;
        public const string databaseConnection = "Server=(localdb)//mssqllocaldb;Database=FeedbackDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public const string azureDbConnection = "Server=tcp:localptazure.database.windows.net,1433;Initial Catalog=FeedbackDb;Persist Security Info=False;User ID=adminsql;Password=sqlpsw_2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private ApplicationDbContext _context { get; }

        public IConfiguration Configuration { get; }

        public CustomerFeedbackRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public IUnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return _context;
        //    }
        //}

        public CustomerFeedbackRepository()
        {
            //options =>options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"))
        }

        public object Save(string firstname, string lastname, string comment)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(azureDbConnection);
                //"Server=(localdb)//mssqllocaldb;Database=FeedbackDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                //Configuration.GetConnectionString("DatabaseConnection"));

            using (ApplicationDbContext context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var _feedback = new Feedback
                {
                    /*Id = 1,*/
                    FirstName = firstname,
                    Lastname = lastname,
                    Comment = comment
                };

                return Guid.Parse(string.Format("00000000-0000-0000-0000-00{0:0000000000}", context.Add(_feedback).Entity.Id));
            }
         }
    }
}