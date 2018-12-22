using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaffeSimulation;
using SimulatedCaffe;

namespace UnitTestProj
{
    [TestClass]
    public class UnitTest1
    {
        public PeopleFactory customerFact = new CustomerFactory();
        public PeopleFactory staffFact = new StaffFactory();
        [TestMethod]
        public void TestMethod1()
        {
            int oldBudget;
            Dialogue dialogue = new Dialogue();
            CustomerInPlace cust = (CustomerInPlace)customerFact.CreatePeople("0", 0, 0, new NewComer());
            cust.budget = 200;
            oldBudget = cust.budget;
            Waiter staff = (Waiter)staffFact.CreatePeople("0", 0, 0, new WaiterPending());
            dialogue.GetOrder(ref staff, ref cust);
            cust.Request();
            Assert.AreNotEqual(cust.budget, oldBudget);
        }
    }
}
