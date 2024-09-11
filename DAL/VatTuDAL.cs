using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class VatTuDAL : Database
    {
        // Hàm hiển thị ds vật tư
        public List<VatTu> HienThiDanhSachVatTu()
        {
            List<VatTu> ds = new List<VatTu>();
            OpenConnection();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from VATTU";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                string dvt = reader.GetString(2);
                double phanTram = (double)reader.GetFloat(3);
                VatTu vt = new VatTu();
                vt.MaVTu = ma;
                vt.TenVTu = ten;
                vt.DVTinh = dvt;
                vt.PhanTram = phanTram;
                ds.Add(vt);
            }
            reader.Close();
            return ds;
        }
        public bool ThemVT(VatTu vt)
        {
            OpenConnection();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into VATTU values (@ma, @ten, @dvt,@phanTram)";
            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.Char);
            parMa.Value = vt.MaVTu;
            sqlCmd.Parameters.Add(parMa);
            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = vt.TenVTu;
            sqlCmd.Parameters.Add(parTen);
            SqlParameter parDVT = new SqlParameter("@dvt", SqlDbType.NVarChar);
            parDVT.Value = vt.DVTinh;
            sqlCmd.Parameters.Add(parDVT);
            SqlParameter parDG = new SqlParameter("@phanTram", SqlDbType.Real);
            parDG.Value = vt.PhanTram;
            sqlCmd.Parameters.Add(parDG);
            sqlCmd.Connection = sqlCon;
            int kt = sqlCmd.ExecuteNonQuery();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool XoaVT(VatTu vt)
        {
            OpenConnection();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from VATTU where MAVTu = @ma ";
            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.Char);
            parMa.Value = vt.MaVTu;
            sqlCmd.Parameters.Add(parMa);
            sqlCmd.Connection = sqlCon;
            int kt = sqlCmd.ExecuteNonQuery();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SuaVT(VatTu vt)
        {
            OpenConnection();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update VATTU set MAVTu= @ma, TenVTu = @ten, DvTinh = @dvt, PhanTram = @phanTram where MAVTu = @ma ";
            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.Char);
            parMa.Value = vt.MaVTu;
            sqlCmd.Parameters.Add(parMa);
            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = vt.TenVTu;
            sqlCmd.Parameters.Add(parTen);
            SqlParameter parDVT = new SqlParameter("@dvt", SqlDbType.NVarChar);
            parDVT.Value = vt.DVTinh;
            sqlCmd.Parameters.Add(parDVT);
            SqlParameter parDG = new SqlParameter("@phanTram", SqlDbType.Real);
            parDG.Value = vt.PhanTram;
            sqlCmd.Parameters.Add(parDG);
            sqlCmd.Connection = sqlCon;
            int kt = sqlCmd.ExecuteNonQuery();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
