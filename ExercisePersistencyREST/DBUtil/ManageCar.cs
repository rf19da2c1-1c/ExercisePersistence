using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ExercisePersistenceLib.model;

namespace ExercisePersistencyREST.DBUtil
{
    public class ManageCar
    {
        private const String GETALL_SQL = "select * from Car";
        public ICollection<Car> GetAll()
        {
            List<Car> cars = new List<Car>();

            SqlCommand sqlcmd = DBSingleton.Instance.GetSQLCommand(GETALL_SQL);
            using (var data = sqlcmd.ExecuteReader())
            {

                while (data.Read())
                {
                    cars.Add(ReadNextCar(data));
                }
            }

            return cars;
        }

        private const String GETONE_SQL = "select * from Car where Id = @ID";
        public Car GetOne(int id)
        {
            Car car = null;

            SqlCommand sqlcmd = DBSingleton.Instance.GetSQLCommand(GETONE_SQL);
            sqlcmd.Parameters.AddWithValue("@ID", id);

            using (var data = sqlcmd.ExecuteReader())
            {
                while (data.Read())
                {
                    car = ReadNextCar(data);
                }
            }

            return car;
        }


        private const String INSERT_SQL = "insert into Car (Model,Vendor,Price) values (@MODEL, @VENDOR, @PRICE)";
        public bool CreateOne(Car c)
        {
            SqlCommand sqlcmd = DBSingleton.Instance.GetSQLCommand(INSERT_SQL);
            sqlcmd.Parameters.AddWithValue("@MODEL", c.Model);
            sqlcmd.Parameters.AddWithValue("@VENDOR", c.Vendor);
            sqlcmd.Parameters.AddWithValue("@PRICE", c.Price);

            return sqlcmd.ExecuteNonQuery() == 1;
        }








        private const String UPDATE_SQL = "update Car set Model=@MODEL, Vendor=@VENDOR, Price=@PRICE where Id = @ID";
        public bool UpdateOne(int id, Car c)
        {
            Car car = GetOne(id);
            if (car == null)
            {
                return false;
            }

            SqlCommand sqlcmd = DBSingleton.Instance.GetSQLCommand(UPDATE_SQL);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.Parameters.AddWithValue("@MODEL", c.Model);
            sqlcmd.Parameters.AddWithValue("@VENDOR", c.Vendor);
            sqlcmd.Parameters.AddWithValue("@PRICE", c.Price);

            return sqlcmd.ExecuteNonQuery() == 1;
        }



        private const String DELETE_SQL = "delete from Car where Id = @ID";
        public Car DeleteOne(int id)
        {
            Car car = GetOne(id);
            if (car == null)
            {
                return null;
            }

            SqlCommand sqlcmd = DBSingleton.Instance.GetSQLCommand(DELETE_SQL);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            
            return (sqlcmd.ExecuteNonQuery() == 1) ? car : null;
        }

        private Car ReadNextCar(SqlDataReader data)
        {
            Car car = new Car();
            car.Id = data.GetInt32(0);
            car.Model = data.GetString(1);
            car.Vendor = data.GetString(2);
            car.Price = data.GetDouble(3);
            return car;
        }
    }
}