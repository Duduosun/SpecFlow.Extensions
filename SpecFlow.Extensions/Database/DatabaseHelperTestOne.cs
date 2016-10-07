using System.Collections.Generic;

namespace SpecFlow.Extensions.Database
{
    public class DatabaseHelperTestOne
    {
        private const string Table_Person = "dbo.Person";
        private const string Table_Address = "dbo.Address";
        private static DatabaseHelper _databaseHelper = new DatabaseHelper(DatabaseHelper.DATABASE_TEST_ONE);

        public string GetFullName(string nickname)
        {
            var dt = _databaseHelper.Select("First, Last", Table_Person, SQL.Criterion("Nickname", nickname));
            return string.Format("{0} {1}", dt.Rows[0]["First"], dt.Rows[0]["Last"]);
        }

        public int GetAddressId(string address1, string address2, string city, string state, int zip)
        {
            return _databaseHelper.GetIntegerValue("AddressId", Table_Address, new List<SQL>
                                                        {
                                                            SQL.Criterion("Address1", address1),
                                                            SQL.And("Address2", address2),
                                                            SQL.And("City", city),
                                                            SQL.And("State", state),
                                                            SQL.And("Zip", zip)
                                                        }
                                                    );
        }
    }
}