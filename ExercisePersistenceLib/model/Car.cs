using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisePersistenceLib.model
{
    /// <summary>
    /// Model class for exercise in persistency
    /// </summary>
    public class Car
    {
        /*
         * instance fields 
         */
        private int _id;
        private string _model;
        private string _vendor;
        private double _price;
        private static int counter = 0; // automatic counts no of objects use for id setting 

        /*
         * properties
         */
        /// <summary>
        /// Gets and sets the id of this car object
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Gets and sets the model of this car object e.g. polo
        /// </summary>
        public string Model
        {
            get => _model;
            set => _model = value;
        }

        /// <summary>
        /// Gets and sets the vendor of this car object e.g. vw
        /// </summary>
        public string Vendor
        {
            get => _vendor;
            set => _vendor = value;
        }

        /// <summary>
        /// Gets and sets the price of this car object must be zero or a positive number
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0) throw  new ArgumentException("Price must be zero or positive");
                _price = value;
            }
        }


        /*
         * Constructors
         */
        /// <summary>
        /// The default constructor set vendor + model to 'dummy' and price to 0
        /// </summary>
        public Car():this("dummy","dummy",0)
        {
        }

        /// <summary>
        /// Constructor to set initial values for the properties of the car
        /// </summary>
        /// <param name="model">The model of the car e.g. 'polo'</param>
        /// <param name="vendor">The vendor of the car e.g. 'VW'</param>
        /// <param name="price">The price of the car e.g. 125000</param>
        public Car(string model, string vendor, double price)
        {
            _id = counter++;
            _model = model;
            _vendor = vendor;
            Price = price; // use the property for checking constraints
        }

        /*
         * ToString
         */
        /// <summary>
        /// Built a string of the values of the properties
        /// </summary>
        /// <returns>A string with the property values </returns>
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Model)}: {Model}, {nameof(Vendor)}: {Vendor}, {nameof(Price)}: {Price}";
        }


        /*
         * Equals etc.
         */
        /// <summary>
        /// Checking if this car is logical the same as the other car - based on the 'id'
        /// </summary>
        /// <param name="other">the car object to be checking against</param>
        /// <returns></returns>
        protected bool Equals(Car other)
        {
            return _id == other._id;
        }

        /// <summary>
        /// Checking if two objects (cars) are the same i.e. have the same 'id'
        /// </summary>
        /// <param name="obj">the object to be checking against</param>
        /// <returns>true if the two objects are logical the same</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Car) obj);
        }
        /// <summary>
        /// Generate the hashcode based on the 'id' of this car object
        /// </summary>
        /// <returns>the hashcode</returns>
        public override int GetHashCode()
        {
            return _id;
        }
    }
}
