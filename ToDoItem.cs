using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList

{
    public class ToDoItem
    {
        public string title;
        public string description;
        public DateTime date;

        public ToDoItem(string title, string descripton, DateTime date )
        {
            this.title = title;
            this.description = descripton;
            this.date = date;
        }

        public ToDoItem()
        {
                
        }

        public override string ToString()
        { 
            return title + ", " + description + ", " + date.ToString("yyyy-MM-dd");
        }
    }
}
