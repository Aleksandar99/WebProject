using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.ControllersNU
{

    public class CNU
    {
        public static bool AddIsOK(Worker worker)
        {
            WebProject.Data.WebProjectContext webProjectContext = new Data.WebProjectContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Data.WebProjectContext>());

            int count = webProjectContext.Worker.Count();

            webProjectContext.Add(worker);

            return Assert.Equals(count + 1, webProjectContext.Worker.Count());
        }

        public static bool RemoveIsOK(Worker worker)
        {
            WebProject.Data.WebProjectContext webProjectContext = new Data.WebProjectContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Data.WebProjectContext>());

            int count = webProjectContext.Worker.Count();

            webProjectContext.Remove(worker);

            return Assert.Equals(count - 1, webProjectContext.Worker.Count());
        }

        public static bool UpdateIsOK(Worker worker)
        {
            WebProject.Data.WebProjectContext webProjectContext = new Data.WebProjectContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Data.WebProjectContext>());

            string newWorkerName = worker.FirstName + worker.FirstName + worker.FirstName;

            worker.FirstName = newWorkerName;

            webProjectContext.Update(worker);

            return Assert.Equals(worker.FirstName, newWorkerName);
        }

        public static void DetailsIsOK(int workerId)
        {
            WebProject.Data.WebProjectContext webProjectContext = new Data.WebProjectContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Data.WebProjectContext>());

            Worker worker = webProjectContext.Worker.FirstOrDefault(a => a.Id == workerId);

            Assert.IsNotNull(worker, "Null on id = " + workerId);
        }

        public static void SetIdIsOK(int workerId, int newWorkerId)
        {
            WebProject.Data.WebProjectContext webProjectContext = new Data.WebProjectContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Data.WebProjectContext>());

            Worker worker = webProjectContext.Worker.FirstOrDefault(a => a.Id == workerId);

            worker.Id = newWorkerId;

            try
            {
                webProjectContext.Update(worker);

                Assert.Fail();

            }
            catch (Exception)
            {
                Assert.Pass("Id is not set", "id = " + workerId);
            }

        }


    }
}
