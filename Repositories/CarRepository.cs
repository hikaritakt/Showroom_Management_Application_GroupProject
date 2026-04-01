using Microsoft.Data.SqlClient;
SELECT c.car_id, c.car_name, c.price, c.quantity, c.brand_id,
       b.brand_name,
       c.model_id, ISNULL(m.model_name, '') AS model_name,
       c.color_id, ISNULL(cl.color_name, '') AS color_name,
       c.status_id, ISNULL(s.status_name, '') AS status_name
                FROM Car c
                INNER JOIN Brand b ON c.brand_id = b.brand_id
                LEFT JOIN CarModel m ON c.model_id = m.model_id
                LEFT JOIN Color cl ON c.color_id = cl.color_id
                LEFT JOIN CarStatus s ON c.status_id = s.status_id
                ORDER BY c.car_id DESC";

            var table = DBHelper.ExecuteQuery(query);
return table.AsEnumerable().Select(row => new CarItem
{
    CarId = row.Field<int>("car_id"),
    CarName = row.Field<string>("car_name") ?? string.Empty,
    Price = row.Field<decimal>("price"),
    Quantity = row.Field<int>("quantity"),
    BrandId = row.Field<int>("brand_id"),
    BrandName = row.Field<string>("brand_name") ?? string.Empty,
    ModelId = row.Field<int?>("model_id"),
    ModelName = row.Field<string>("model_name") ?? string.Empty,
    ColorId = row.Field<int?>("color_id"),
    ColorName = row.Field<string>("color_name") ?? string.Empty,
    StatusId = row.Field<int?>("status_id"),
    StatusName = row.Field<string>("status_name") ?? string.Empty
}).ToList();
        }

        public void Add(CarItem car)
{
    const string query = @"
                INSERT INTO Car(car_name, price, quantity, brand_id, model_id, color_id, status_id)
                VALUES (@car_name, @price, @quantity, @brand_id, @model_id, @color_id, @status_id)";

    DBHelper.ExecuteNonQuery(query,
        new SqlParameter("@car_name", car.CarName),
        new SqlParameter("@price", car.Price),
        new SqlParameter("@quantity", car.Quantity),
        new SqlParameter("@brand_id", car.BrandId),
        new SqlParameter("@model_id", (object?)car.ModelId ?? DBNull.Value),
        new SqlParameter("@color_id", (object?)car.ColorId ?? DBNull.Value),
        new SqlParameter("@status_id", (object?)car.StatusId ?? DBNull.Value));
}

public void Update(CarItem car)
{
    const string query = @"
                UPDATE Car
                SET car_name = @car_name,
                    price = @price,
                    quantity = @quantity,
                    brand_id = @brand_id,
                    model_id = @model_id,
                    color_id = @color_id,
                    status_id = @status_id
                WHERE car_id = @car_id";

    DBHelper.ExecuteNonQuery(query,
        new SqlParameter("@car_id", car.CarId),
        new SqlParameter("@car_name", car.CarName),
        new SqlParameter("@price", car.Price),
        new SqlParameter("@quantity", car.Quantity),
        new SqlParameter("@brand_id", car.BrandId),
        new SqlParameter("@model_id", (object?)car.ModelId ?? DBNull.Value),
        new SqlParameter("@color_id", (object?)car.ColorId ?? DBNull.Value),
        new SqlParameter("@status_id", (object?)car.StatusId ?? DBNull.Value));
}

public void Delete(int carId)
{
    DBHelper.ExecuteNonQuery("DELETE FROM Car WHERE car_id = @car_id",
        new SqlParameter("@car_id", carId));
}
    }
}