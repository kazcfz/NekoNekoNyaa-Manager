using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PassTask3{
    [TestFixture]
    public class UnitTests{
        [Test]
        public void TotalPurchaseTest(){
            Staff shopadmin1 = new Staff(1001,"admin123",StaffPosition.ShopAdmin);
            Customer customer1 = new Customer(1234, "Alex", Membership.Normal, 0);

            List<Purchases> _purchases = new List<Purchases>();
            Purchases [] purchaselist = {
                new Purchases(0001, "01/01/2021", 100, customer1),
                new Purchases(0002, "02/01/2021", 200, customer1)
            };

            foreach(Purchases p in purchaselist){
                _purchases.Add(p);
                customer1.UpdateTotalPurchase(p);
            }

            Assert.AreEqual(purchaselist[1].Customer.TotalPurchase,300);
        }

        [Test]
        public void FetchingTest(){
            Staff shopadmin1 = new Staff(1001,"admin123",StaffPosition.ShopAdmin);
            Customer customer1 = new Customer(1234, "Alex", Membership.Normal, 100);

            List<Purchases> _purchases = new List<Purchases>();
            Purchases [] purchaselist = {
                new Purchases(0001, "01/01/2021", 100, customer1),
                new Purchases(0002, "02/01/2021", 200, customer1)
            };

            foreach(Purchases p in purchaselist){
                shopadmin1.Purchases.Add(p);
            }
            Assert.AreEqual(customer1,purchaselist[0].Customer);
        }

        [Test]
        public void UpdateBookingAmountTest(){
            Staff shopadmin1 = new Staff(1001, "password123", StaffPosition.ShopAdmin);

            Customer customer1 = new Customer(1234, "Alex", Membership.Normal, 100);

            List<Booking> _booking = new List<Booking>();
            Booking [] booklist = {
                new Booking(2,"02/05/2021",13,4,customer1)
                //new Booking(10,"10/05/2021",15,3,customer1)
            };
            _booking.AddRange(booklist);

            foreach (Booking b in _booking){
                b.UpdateAmount(b);
            }

            Assert.AreEqual(_booking[0].Amount,20);
        }
    }
}