using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace KyleHynes_TimeTrackerApp
{
    class Program
    {

        MySqlConnection _con = null;
        

        static void Main(string[] args)
        {
            List<string> categories = new List<string>();
            List<string> dates = new List<string>();
            List<string> descriptions = new List<string>();

            Program instance = new Program();
            MySqlCommand Cmd = new MySqlCommand();


            instance._con = new MySqlConnection();
            instance.Connect();

            DataTable data = instance.QueryDB("SELECT activity_category FROM activity_categories");
            DataRowCollection rows = data.Rows;

            foreach (DataRow row in rows)
            {
                string category = row["activity_category"].ToString();
                categories.Add(category);
            }

            data = instance.QueryDB("SELECT calendar_date FROM tracked_calendar_dates");
            rows = data.Rows;

            foreach (DataRow row in rows)
            {
                string date = row["calendar_date"].ToString();
                DateTime dataDate = DateTime.Parse(date);
                date = dataDate.ToShortDateString();
                dates.Add(date);
            }

            data = instance.QueryDB("SELECT activity_description FROM activity_descriptions");
            rows = data.Rows;

            foreach (DataRow row in rows)
            {
                string description = row["activity_description"].ToString();
                descriptions.Add(description);
            }

            bool programisRunning = true;
            while (programisRunning)
            {
                Console.Clear();
                Console.WriteLine("TIME TRACKER APP\n================\n");
                Console.WriteLine("What would you like to do today?\n");
                Console.WriteLine(
                    "1) Enter Activity\n" +
                    "2) View Tracked Data\n" +
                    "3) Run Calculations\n" +
                    "4) Exit\n");
                Console.Write("Selection: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "one":
                        {
                            bool menuLoop1 = true;
                            string catSelect = null;
                            int monthDay;
                            string dateSelect = null;
                            string descriptionSelect = null;
                            double timeSpent;

                            while (menuLoop1)
                            {
                                Console.Clear();
                                Console.WriteLine("Pick A Category Of Activity\n================\n");
                                int i = 1;
                                foreach (string cat in categories)
                                {
                                    Console.WriteLine($"{i}) {cat}");
                                    i++;
                                }
                                Console.WriteLine("\n0) Exit\n");

                                int index = Validation.GetInt(0, categories.Count, "Selection: ");

                                if (index == 0)
                                {
                                    menuLoop1 = false;
                                }
                                else
                                {
                                    int catIndex = index;
                                    index--;
                                    catSelect = categories[index];

                                    bool menuLoop2 = true;
                                    while (menuLoop2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Pick An Activity Description\n================\n");

                                        i = 1;
                                        foreach (string a in descriptions)
                                        {
                                            Console.WriteLine($"{i}) {a}");
                                            i++;
                                        }
                                        Console.WriteLine("\n0) Exit\n");

                                        int index2 = Validation.GetInt(0, descriptions.Count, "Selection: ");

                                        if (index2 == 0)
                                        {
                                            menuLoop2 = false;
                                        }
                                        else
                                        {
                                            int actIndex = index2;
                                            index2--;
                                            descriptionSelect = descriptions[index2];

                                            bool menuLoop3 = true;
                                            while (menuLoop3)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("What Date Did You Perform Activity\n================\n");

                                                i = 1;
                                                foreach (string d in dates)
                                                {
                                                    Console.WriteLine($"{i}) {d}");
                                                    i++;
                                                }
                                                Console.WriteLine("\n0) Exit\n");

                                                int index3 = Validation.GetInt(0, dates.Count, "Selection: ");

                                                if (index3 == 0)
                                                {
                                                    menuLoop3 = false;
                                                }
                                                else
                                                {
                                                    monthDay = index3;
                                                    
                                                    int dateIndex = index3;
                                                    index3--;
                                                    dateSelect = dates[index3];

                                                    bool menuLoop4 = true;
                                                    while (menuLoop4)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("How Long Did You Perform That Activity?\n================\n");
                                                        Console.WriteLine("Keep in mind ever 15 minutes is represented as a 0.25: Format: 0.00\n");

                                                        double timeEntry = Validation.GetDouble(.25, "Time Spent On Activity (enter 0 to exit): ");

                                                        if (timeEntry == 0)
                                                        {
                                                            menuLoop4 = false;
                                                        }
                                                        else
                                                        {
                                                            timeSpent = timeEntry;

                                                            bool menuLoop5 = true;
                                                            while (menuLoop5)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Activity Entry Confirmation\n================\n");

                                                                Console.WriteLine(
                                                                    $"Category: {catSelect}\n" +
                                                                    $"Description: {descriptionSelect}\n" +
                                                                    $"Date: {dateSelect}\n" +
                                                                    $"Time Spent: {timeSpent}\n");

                                                                Console.Write("Confirm Entry: Yes or No: ");
                                                                string entryConfirm = Console.ReadLine().ToLower();

                                                                switch (entryConfirm)
                                                                {
                                                                    case "yes":
                                                                    case "y":
                                                                        {
                                                                            /*
                                                                            Cmd = new MySqlCommand($"SELECT calendar_date_id FROM tracked_calendar_dates WHERE calendar_date = @dateSelect");
                                                                            Cmd.Parameters.Add("@dateSelect", dateSelect);
                                                                            Cmd.ExecuteNonQuery();
                                                                            */

                                                                            int tSpent = TimeSpent(timeSpent);
                                                                            int dayName = DayName(dateIndex);

                                                                            string sq = $"INSERT INTO activity_log (calendar_day, calendar_date, day_name, category_description, activity_description, time_spent_on_activity) VALUES ({monthDay}, {dateIndex}, {dayName}, {catIndex}, {actIndex}, {tSpent});";
                                                                            data = instance.QueryDB(sq);

                                                                            Console.Clear();
                                                                            Console.WriteLine("Activity Successfully Entered\n================\n");
                                                                            Console.WriteLine(
                                                                                "1) Enter Another Activity\n" +
                                                                                "2) Back to Main Menu\n");
                                                                            Console.Write("Selection: ");
                                                                            string s = Console.ReadLine().ToLower();

                                                                            switch (s)
                                                                            {
                                                                                case "1":
                                                                                case "one":
                                                                                    {
                                                                                        menuLoop2 = false;
                                                                                        menuLoop3 = false;
                                                                                        menuLoop4 = false;
                                                                                        menuLoop5 = false;
                                                                                    }
                                                                                    break;
                                                                                case "2":
                                                                                case "two":
                                                                                    {
                                                                                        menuLoop1 = false;
                                                                                        menuLoop2 = false;
                                                                                        menuLoop3 = false;
                                                                                        menuLoop4 = false;
                                                                                        menuLoop5 = false;
                                                                                    }
                                                                                    break;
                                                                            }
                                                                        }
                                                                        break;
                                                                    case "no":
                                                                    case "n":
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine("============\nEntry Canceled...\n\nPress any key to return...\n============\n");
                                                                            Console.ReadKey();

                                                                            menuLoop2 = false;
                                                                            menuLoop3 = false;
                                                                            menuLoop4 = false;
                                                                            menuLoop5 = false;
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                        }
                                                        
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        break;
                    case "2":
                    case "two":
                        {
                            bool menu2Loop = true;
                            while (menu2Loop)
                            {
                                Console.Clear();
                                Console.WriteLine("View Tracked Data Menu\n================\n");
                                Console.WriteLine(
                                    "1) Select By Date\n" +
                                    "2) Select By Category\n" +
                                    "3) Select by Description\n" +
                                    "4) Back\n");
                                Console.Write("Selection: ");

                                string menuSelect2 = Console.ReadLine().ToLower();

                                switch (menuSelect2)
                                {
                                    case "1":
                                    case "one":
                                    case "date":
                                        {
                                            bool m2L1 = true;
                                            while (m2L1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("What Date Would You Like To View?\n================\n");

                                                int i2 = 1;
                                                foreach (string d in dates)
                                                {
                                                    Console.WriteLine($"{i2}) {d}");
                                                    i2++;
                                                }
                                                Console.WriteLine("\n0) Back\n");

                                                int indexA = Validation.GetInt(0, dates.Count, "Selection: ");

                                                if (indexA == 0)
                                                {
                                                    m2L1 = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();

                                                    data = instance.QueryDB(
                                                        "SELECT activity_descriptions.activity_description " +
                                                        "FROM activity_log JOIN activity_descriptions " +
                                                        "ON activity_log.activity_description = activity_description_id " +
                                                        $"where calendar_date = {indexA};");
                                                    rows = data.Rows;
                                                    int indexB = indexA;
                                                    indexB--;
                                                    Console.WriteLine($"All Logged Activities on {dates[indexB]}\n================\n");

                                                    int n = 1;

                                                    foreach (DataRow row in rows)
                                                    {
                                                        Console.WriteLine($"**{row["activity_description"].ToString()}");
                                                        n++;
                                                    }

                                                    data = instance.QueryDB(
                                                        "SELECT SUM(activity_times.time_spent_on_activity), 24 - SUM(activity_times.time_spent_on_activity) " +
                                                        "FROM activity_log JOIN activity_times " +
                                                        "ON activity_log.time_spent_on_activity = activity_time_id " +
                                                        $"where calendar_date = {indexA};");
                                                    rows = data.Rows;

                                                    Console.Write("\n");
                                                    foreach (DataRow row in rows)
                                                    {
                                                        Console.WriteLine($"Total Hours Tracked: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                                        Console.WriteLine($"Total Untracked Hours: {row["24 - SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                                    }
                                                    Console.Write("\n");
                                                    Console.WriteLine(
                                                        "1) Enter Activity For This Day\n" +
                                                        "2) Back\n");
                                                    Console.Write("Selection: ");
                                                    string input2 = Console.ReadLine().ToLower();
                                                    switch (input2)
                                                    {
                                                        case "1":
                                                        case "one":
                                                            {
                                                                bool menuLoop1 = true;
                                                                string catSelect = null;
                                                                int monthDay;
                                                                string dateSelect = null;
                                                                string descriptionSelect = null;
                                                                double timeSpent;

                                                                while (menuLoop1)
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Pick A Category Of Activity\n================\n");
                                                                    int i = 1;
                                                                    foreach (string cat in categories)
                                                                    {
                                                                        Console.WriteLine($"{i}) {cat}");
                                                                        i++;
                                                                    }
                                                                    Console.WriteLine("\n0) Exit\n");

                                                                    int index = Validation.GetInt(0, categories.Count, "Selection: ");

                                                                    if (index == 0)
                                                                    {
                                                                        menuLoop1 = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        int catIndex = index;
                                                                        index--;
                                                                        catSelect = categories[index];

                                                                        bool menuLoop2 = true;
                                                                        while (menuLoop2)
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine("Pick An Activity Description\n================\n");

                                                                            i = 1;
                                                                            foreach (string a in descriptions)
                                                                            {
                                                                                Console.WriteLine($"{i}) {a}");
                                                                                i++;
                                                                            }
                                                                            Console.WriteLine("\n0) Exit\n");

                                                                            int index2 = Validation.GetInt(0, descriptions.Count, "Selection: ");

                                                                            if (index2 == 0)
                                                                            {
                                                                                menuLoop2 = false;
                                                                            }
                                                                            else
                                                                            {
                                                                                int actIndex = index2;
                                                                                index2--;
                                                                                descriptionSelect = descriptions[index2];

                                                                                bool menuLoop3 = true;
                                                                                while (menuLoop3)
                                                                                {
                                                                                    
                                                                                            Console.Clear();
                                                                                            Console.WriteLine("How Long Did You Perform That Activity?\n================\n");
                                                                                            Console.WriteLine("Keep in mind ever 15 minutes is represented as a 0.25: Format: 0.00\n");

                                                                                            double timeEntry = Validation.GetDouble(.25, "Time Spent On Activity (enter 0 to exit): ");

                                                                                            if (timeEntry == 0)
                                                                                            {
                                                                                                menuLoop3 = false;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                timeSpent = timeEntry;

                                                                                                bool menuLoop4 = true;
                                                                                                while (menuLoop4)
                                                                                                {
                                                                                                    Console.Clear();
                                                                                                    Console.WriteLine("Activity Entry Confirmation\n================\n");

                                                                                                    Console.WriteLine(
                                                                                                        $"Category: {catSelect}\n" +
                                                                                                        $"Description: {descriptionSelect}\n" +
                                                                                                        $"Date: {dates[indexB]}\n" +
                                                                                                        $"Time Spent: {timeSpent}\n");

                                                                                                    Console.Write("Confirm Entry: Yes or No: ");
                                                                                                    string entryConfirm = Console.ReadLine().ToLower();

                                                                                                    switch (entryConfirm)
                                                                                                    {
                                                                                                        case "yes":
                                                                                                        case "y":
                                                                                                            {
                                                                                                                /*
                                                                                                                Cmd = new MySqlCommand($"SELECT calendar_date_id FROM tracked_calendar_dates WHERE calendar_date = @dateSelect");
                                                                                                                Cmd.Parameters.Add("@dateSelect", dateSelect);
                                                                                                                Cmd.ExecuteNonQuery();
                                                                                                                */

                                                                                                                int tSpent = TimeSpent(timeSpent);
                                                                                                                int dayName = DayName(indexA);

                                                                                                                string sq = $"INSERT INTO activity_log (calendar_day, calendar_date, day_name, category_description, activity_description, time_spent_on_activity) VALUES ({indexA}, {indexA}, {dayName}, {catIndex}, {actIndex}, {tSpent});";
                                                                                                                data = instance.QueryDB(sq);

                                                                                                                Console.Clear();
                                                                                                                Console.WriteLine("Activity Successfully Entered\n================\n");
                                                                                                                Console.WriteLine(
                                                                                                                    "1) Enter Another Activity\n" +
                                                                                                                    "2) Back to Main Menu\n");
                                                                                                                Console.Write("Selection: ");
                                                                                                                string s = Console.ReadLine().ToLower();

                                                                                                                switch (s)
                                                                                                                {
                                                                                                                    case "1":
                                                                                                                    case "one":
                                                                                                                        {
                                                                                                                            menuLoop2 = false;
                                                                                                                            menuLoop3 = false;
                                                                                                                            menuLoop4 = false;
                                                                                                                        }
                                                                                                                        break;
                                                                                                                    case "2":
                                                                                                                    case "two":
                                                                                                                        {
                                                                                                                            menuLoop1 = false;
                                                                                                                            menuLoop2 = false;
                                                                                                                            menuLoop3 = false;
                                                                                                                            menuLoop4 = false;
                                                                                                                    menu2Loop = false;
                                                                                                                    m2L1 = false;
                                                                                                                        }
                                                                                                                        break;
                                                                                                                }
                                                                                                            }
                                                                                                            break;
                                                                                                        case "no":
                                                                                                        case "n":
                                                                                                            {
                                                                                                                Console.Clear();
                                                                                                                Console.WriteLine("============\nEntry Canceled...\n\nPress any key to return...\n============\n");
                                                                                                                Console.ReadKey();

                                                                                                                menuLoop2 = false;
                                                                                                                menuLoop3 = false;
                                                                                                                menuLoop4 = false;
                                                                                                            }
                                                                                                            break;
                                                                                                    }
                                                                                                }
                                                                                            }  
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                            break;
                                                        case "2":
                                                        case "two":
                                                        case "back":
                                                            {

                                                            }
                                                            break;
                                                    }
                                                    Console.ReadKey();

                                                }
                                            }
                                        }
                                        break;
                                    case "2":
                                    case "two":
                                    case "category":
                                        {
                                            bool m2L2 = true;
                                            while (m2L2)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("What Category Would You Like To View?\n================\n");

                                                int i2 = 1;
                                                foreach (string c in categories)
                                                {
                                                    Console.WriteLine($"{i2}) {c}");
                                                    i2++;
                                                }
                                                Console.WriteLine("\n0) Back\n");

                                                int indexA = Validation.GetInt(0, categories.Count, "Selection: ");

                                                if (indexA == 0)
                                                {
                                                    m2L2 = false;
                                                }
                                                else
                                                {

                                                    Console.Clear();

                                                    data = instance.QueryDB(
                                                        "SELECT activity_descriptions.activity_description, tracked_calendar_dates.calendar_date, activity_times.time_spent_on_activity " +
                                                        "FROM activity_log " +
                                                        "JOIN activity_descriptions ON activity_log.activity_description = activity_description_id " +
                                                        "JOIN tracked_calendar_dates ON activity_log.calendar_date = calendar_date_id " +
                                                        "JOIN activity_times ON activity_log.time_spent_on_activity = activity_time_id " +
                                                        $"where category_description = {indexA};");

                                                    rows = data.Rows;
                                                    int indexB = indexA;
                                                    indexB--;

                                                    Console.WriteLine($"All Tracked Data For Category: {categories[indexB]}\n================\n");

                                                    Console.WriteLine("Activity - Date - Time Spent\n");

                                                    foreach (DataRow row in rows)
                                                    {
                                                        Console.WriteLine(
                                                            $"**{row["activity_description"].ToString()} - " +
                                                            $"{row["calendar_date"].ToString()} - " +
                                                            $"{row["time_spent_on_activity"].ToString()}");
                                                    }

                                                    Console.Write("\n");

                                                    data = instance.QueryDB(
                                                        "SELECT SUM(activity_times.time_spent_on_activity) " +
                                                        "FROM activity_log JOIN activity_times " +
                                                        "ON activity_log.time_spent_on_activity = activity_time_id " +
                                                        $"where category_description = {indexA};");
                                                    rows = data.Rows;

                                                    foreach (DataRow row in rows)
                                                    {
                                                        Console.WriteLine($"Total hours logged for category: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                                            
                                                    }
                                                    Console.WriteLine("\nPress any key to go back...");
                                                    Console.ReadKey();

                                                }
                                            }
                                        }
                                        break;
                                    case "3":
                                    case "three":
                                    case "description":
                                        {
                                            bool m2L3 = true;
                                            while (m2L3)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("What Description Would You Like To View?\n================\n");

                                                int i2 = 1;
                                                foreach (string d in descriptions)
                                                {
                                                    Console.WriteLine($"{i2}) {d}");
                                                    i2++;
                                                }
                                                Console.WriteLine("\n0) Back\n");

                                                int indexA = Validation.GetInt(0, categories.Count, "Selection: ");

                                                if (indexA == 0)
                                                {
                                                    m2L3 = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();

                                                    data = instance.QueryDB(
                                                        "SELECT activity_descriptions.activity_description, tracked_calendar_dates.calendar_date, activity_times.time_spent_on_activity " +
                                                        "FROM activity_log " +
                                                        "JOIN activity_descriptions ON activity_log.activity_description = activity_description_id " +
                                                        "JOIN tracked_calendar_dates ON activity_log.calendar_date = calendar_date_id " +
                                                        "JOIN activity_times ON activity_log.time_spent_on_activity = activity_time_id " +
                                                        $"where activity_log.activity_description = {indexA};");

                                                    rows = data.Rows;
                                                    int indexB = indexA;
                                                    indexB--;

                                                    Console.WriteLine($"All Tracked Data For Activity: {descriptions[indexB]}\n================\n");

                                                    Console.WriteLine("Activity - Date - Time Spent\n");

                                                    foreach (DataRow row in rows)
                                                    {
                                                        Console.WriteLine(
                                                            $"**{row["activity_description"].ToString()} - " +
                                                            $"{row["calendar_date"].ToString()} - " +
                                                            $"{row["time_spent_on_activity"].ToString()}");
                                                    }

                                                    Console.Write("\n");

                                                    data = instance.QueryDB(
                                                        "SELECT SUM(activity_times.time_spent_on_activity) " +
                                                        "FROM activity_log JOIN activity_times " +
                                                        "ON activity_log.time_spent_on_activity = activity_time_id " +
                                                        $"where activity_description = {indexA};");
                                                    rows = data.Rows;

                                                    foreach (DataRow row in rows)
                                                    {
                                                        Console.WriteLine($"Total hours logged for activity: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");

                                                    }
                                                    Console.WriteLine("\nPress any key to go back...");
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                        break;
                                    case "4":
                                    case "four":
                                    case "back":
                                        {
                                            menu2Loop = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case "3":
                    case "three":
                        {
                            bool menu3Loop = true;
                            while (menu3Loop)
                            {
                                Console.Clear();

                                Console.WriteLine("Here Are Awesome Facts About The Data Collected!!\n================\n");

                                data = instance.QueryDB(
                                                       "SELECT SUM(activity_times.time_spent_on_activity) " +
                                                       "FROM activity_log JOIN activity_times " +
                                                       "ON activity_log.time_spent_on_activity = activity_time_id ");                      
                                rows = data.Rows;
                                int a = 1;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total of hours tracked for all activites: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB(
                                                       "SELECT SUM(activity_times.time_spent_on_activity) " +
                                                       "FROM activity_log JOIN activity_times " +
                                                       "ON activity_log.time_spent_on_activity = activity_time_id " +
                                                       "where activity_description = 12;");
                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total time spent sleeping: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB(
                                                       "SELECT SUM(activity_times.time_spent_on_activity) " +
                                                       "FROM activity_log JOIN activity_times " +
                                                       "ON activity_log.time_spent_on_activity = activity_time_id " +
                                                       "where category_description = 8;");
                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total time spent driving: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB(
                                                       "SELECT SUM(activity_times.time_spent_on_activity) " +
                                                       "FROM activity_log JOIN activity_times " +
                                                       "ON activity_log.time_spent_on_activity = activity_time_id " +
                                                       "where activity_description = 14;");
                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total time spent playing video games: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB(
                                                       "SELECT SUM(activity_times.time_spent_on_activity) " +
                                                       "FROM activity_log JOIN activity_times " +
                                                       "ON activity_log.time_spent_on_activity = activity_time_id " +
                                                       "where activity_description = 1;");
                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total time spent doing homework: {row["SUM(activity_times.time_spent_on_activity)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB("select count(id) from activity_log;");
                                                       
                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total entires logged: {row["count(id)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB(
                                    "SELECT AVG(activity_log.time_spent_on_activity) " +
                                    "FROM activity_log " +
                                    "WHERE activity_description = 1;");

                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Average time spent on homework: {row["AVG(activity_log.time_spent_on_activity)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB(
                                    "SELECT AVG(activity_log.time_spent_on_activity) " +
                                    "FROM activity_log;");

                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Average time spent on any task: {row["AVG(activity_log.time_spent_on_activity)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB("select count(id) from activity_log where activity_description = 14;");

                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total times played video games: {row["count(id)"].ToString()}");
                                    a++;
                                }

                                data = instance.QueryDB("select count(id) from activity_log where category_description = 1;");

                                rows = data.Rows;
                                foreach (DataRow row in rows)
                                {
                                    Console.WriteLine($"{a}) Total times worked out: {row["count(id)"].ToString()}");
                                    a++;
                                }

                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                                menu3Loop = false;
                            }
                        }
                        break;
                    case "4":
                    case "four":
                    case "exit":
                        {
                            Console.Clear();
                            Console.WriteLine("You have exited the Time Tracker App\n\nHave a great day!\n");
                            programisRunning = false;
                        }
                        break;
                }
            }

        }

        void Connect()
        {
            BuildConString();

            try
            {
                _con.Open();
                Console.WriteLine("Connection Successful");
            }
            catch (MySqlException e)
            {
                string msg = "";
                switch (e.Number)
                {
                    case 0:
                        {
                            msg = e.ToString();
                            break;
                        }
                    case 1042:
                        {
                            msg = "Can't resolve host address.\n" + _con.ConnectionString;
                            break;
                        }
                    case 1045:
                        {
                            msg = "Invalid username/password";
                            break;
                        }
                    default:
                        {
                            msg = e.ToString();
                            break;
                        }
                }

                Console.WriteLine(msg);

            }
        }
        void BuildConString()
        {
            string ip = "";
            using (StreamReader sr = new StreamReader("c:/VFW/connect.txt"))
            {
                ip = sr.ReadLine();
            }

            string conString = $"Server = {ip};";
            conString += "userid=dbremoteuser;";
            conString += "password=password;";
            conString += "database=KyleHynes_MDV229_Database_201811;";
            conString += "port=8889;";

            _con.ConnectionString = conString;
        }
        DataTable QueryDB(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _con);

            DataTable data = new DataTable();

            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(data);

            return data;

        }

        public static int TimeSpent(double _timeSpent)
        {
            int n = 1;
            int dbN = 0;
            double time = .25;

            while (dbN == 0)
            {
                if (_timeSpent == time)
                {
                    dbN = n;
                    
                }
                n++;
                time += .25;
            }

            return dbN;
        }

        public static int DayName(int date)
        {
            int dbN = 0;

            if (date == 1 || date == 8 || date == 15 || date == 22)
            {
                dbN = 1;
            }
            else if (date == 2 || date == 9 || date == 16 || date == 23)
            {
                dbN = 2;
            }
            else if (date == 3 || date == 10 || date == 17 || date == 24)
            {
                dbN = 3;
            }
            else if (date == 4 || date == 11 || date == 18 || date == 25)
            {
                dbN = 4;
            }
            else if (date == 5 || date == 12 || date == 19 || date == 26)
            {
                dbN = 5;
            }
            else if (date == 6 || date == 13 || date == 20)
            {
                dbN = 6;
            }
            else 
            {
                dbN = 7;
            }

            return dbN;
        }

        
    }
}
