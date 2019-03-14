namespace TestProjectForLynxSolutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users (UserName, Password, FirstName, LastName, Email, PhoneNumber) " +
                "VALUES ('kapasrobert', '71ec8645a12f4812abca7c887b3acae428253ceb', 'Robert', 'Kapas', 'kapas.robert.j@gmail.com', '0751531158')");

            Sql("INSERT INTO Users (UserName, Password, FirstName, LastName, Email, PhoneNumber) " +
                "VALUES ('kapasjozsef', '945dc337cb9248dbd4c27a890a3df5a1eab807a1', 'Jozsef', 'Kapas', 'kapas.jozsef@gmail.com', '0751658932')");
        }

        public override void Down()
        {
        }
    }
}
