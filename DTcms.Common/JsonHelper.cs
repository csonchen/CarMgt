using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Data;

namespace FSHH.HQ.XYJ.Web.xyj.Vendor.CertifcateCategory
{
    ///

    /// Json处理类
    /// 

    public class JsonHelper
    {
        /// <summary>
        /// 序列化数据为Json数据格式.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize(object value)
        {
            Type type = value.GetType();

            Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();

            json.NullValueHandling = NullValueHandling.Ignore;

            json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
            json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            if (type == typeof(DataRow))
                json.Converters.Add(new DataRowConverter());
            else if (type == typeof(DataTable))
                json.Converters.Add(new DataTableConverter());
            else if (type == typeof(DataSet))
                json.Converters.Add(new DataSetConverter());

            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonTextWriter writer = new JsonTextWriter(sw);
            //writer.Formatting = Formatting.Indented;
            writer.Formatting = Formatting.None;

            writer.QuoteChar = '"';
            json.Serialize(writer, value);

            string output = sw.ToString();
            writer.Close();
            sw.Close();

            return output;
        }

        /// <summary>
        /// 反序列化Json数据格式.
        /// </summary>
        /// <param name="jsonText"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
 
        public static object Deserialize(string jsonText, Type valueType)
        {
            Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();

            json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
            json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            StringReader sr = new StringReader(jsonText);
            Newtonsoft.Json.JsonTextReader reader = new JsonTextReader(sr);
            object result = json.Deserialize(reader, valueType);
            reader.Close();

            return result;
        }

        /// <summary>
        /// 遍历DataTable的行和列生成Json，可控制性较差
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTable2Json(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(dt.TableName);
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName.ToLower());
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// 遍历DataTable的行和列生成Json，控制数据列，专门为FlexiGrid提供便捷的数据源生成
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static string Json4FlexiGrid(DataTable dt, string cols)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            string[] colarr = cols.Split(',');

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    jsonBuilder.Append("\"id\":");
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i]["ID"].ToString());
                    jsonBuilder.Append("\",\"cell\":[");
                    foreach (string col in colarr)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Rows[i][col].ToString());
                        jsonBuilder.Append("\",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("]},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }

            return jsonBuilder.ToString();
        }

        
    }


    /// <summary>
    ///  Converts a  object to and from JSON.
    /// </summary>

    public class DataRowConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="dataRow"></param>
        /// <param name="ser"></param>
        public override void WriteJson(JsonWriter writer, object dataRow, JsonSerializer ser)
        {
            DataRow row = dataRow as DataRow;

            writer.WriteStartObject();
            foreach (DataColumn column in row.Table.Columns)
            {
                writer.WritePropertyName(column.ColumnName.ToLower());
                ser.Serialize(writer, row[column]);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataRow).IsAssignableFrom(valueType);
        }

        /// <summary>
        ///  Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="ser"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object obj, JsonSerializer ser)
        {
            throw new NotImplementedException();
        }
    }




    /// <summary>
    /// Converts a DataTable to JSON. Note no support for deserialization
    /// </summary>
    public class DataTableConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="dataTable"></param>
        /// <param name="ser"></param>
        public override void WriteJson(JsonWriter writer, object dataTable, JsonSerializer ser)
        {
            DataTable table = dataTable as DataTable;
            DataRowConverter converter = new DataRowConverter();

            writer.WriteStartObject();

            writer.WritePropertyName("Rows");
            writer.WriteStartArray();

            foreach (DataRow row in table.Rows)
            {
                converter.WriteJson(writer, row, ser);
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataTable).IsAssignableFrom(valueType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="ser"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object obj, JsonSerializer ser)
        {
            throw new NotImplementedException();
        }
    }




    /// <summary>
    /// Converts a  object to JSON. No support for reading.
    /// </summary>
    public class DataSetConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="dataset"></param>
        /// <param name="ser"></param>
        public override void WriteJson(JsonWriter writer, object dataset, JsonSerializer ser)
        {
            DataSet dataSet = dataset as DataSet;

            DataTableConverter converter = new DataTableConverter();

            writer.WriteStartObject();

            writer.WritePropertyName("Tables");
            writer.WriteStartArray();

            foreach (DataTable table in dataSet.Tables)
            {
                converter.WriteJson(writer, table, ser);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataSet).IsAssignableFrom(valueType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="ser"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object obj, JsonSerializer ser)
        {
            throw new NotImplementedException();
        }
    }
    

    
}