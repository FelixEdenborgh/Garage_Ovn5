using Garage_Ovn5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class VehicleTests
    {

        [TestMethod]
        public void VehicleTestRegistrationNumberProperty()
        {
            //--Arrage 
            Vehicle vehicle = new Vehicle(5, "Red", 150, "ABC723");

            string expeected = "ABC723";

            //-- Act
            string actual = vehicle.RegistrationNumber;

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }

        [TestMethod]
        public void VehicleTestColorProperty()
        {
            //--Arrage
            Vehicle vehicle = new Vehicle(5, "Red", 150, "ABC723");

            string expeected = "Red";

            //-- Act
            string actual = vehicle.ColorOfVehicle;

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }

        [TestMethod]
        public void VehicleTestNumberOfWheelsProperty()
        {
            //--Arrage
            Vehicle vehicle = new Vehicle(5, "Red", 150, "ABC723");

            string expeected = "5";

            //-- Act
            string actual = vehicle.NumberOfWheels.ToString();

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }

        [TestMethod]
        public void VehicleTestHorsePowerProperty()
        {
            //--Arrage
            Vehicle vehicle = new Vehicle(5, "Red", 150, "ABC723");

            string expeected = "150";

            //-- Act
            string actual = vehicle.HorsePower.ToString();

            //-- Assert
            Assert.AreEqual(expeected , actual);
        }


        [TestMethod]
        public void TestVehicleCarProperty()
        {
            //--Arrage
            Car car = new Car(4, "Blue", 125, "JKJ723", "Disel");

            string expeected = "Disel";

            //-- Act
            string actual = car.Fuel;

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }


        [TestMethod]
        public void TestVehicleBoatProperty()
        {
            //--Arrage
            Boat boat = new Boat(0, "White", 250, "kjk666", true);

            bool expeected = true;

            //-- Act
            bool actual = boat.HasSail;

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }


        [TestMethod]
        public void TestVehicleMotorCycleProperty()
        {
            //--Arrage
            MotorCycle motorCycle = new MotorCycle(2, "Green", 175, "hrb490", false);

            bool expeected = false;

            //-- Act
            bool actual = motorCycle.LightOn;

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }

        [TestMethod]
        public void TestVehiclePlaneProperty()
        {
            //--Arrage
            Plane plane = new Plane(3, "White", 500, "YVN627", 3);

            int expeected = 3;

            //-- Act
            int actual = plane.NumberOfEngines;

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }


        [TestMethod]
        public void TestVehicleBusProperty()
        {
            //--Arrage
            Bus bus = new Bus(6, "Red", 350, "Day163", 60);

            int expeected = 60;

            //-- Act
            int actual = bus.NumberOfSeats;

            //-- Assert
            Assert.AreEqual(expeected, actual);
        }

    }
}
