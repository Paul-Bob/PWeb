using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex1
{
    public class User
    {
        public User(string name) { _name = name; }
        
        private readonly string _name;
        private List<Task> _tasks = new List<Task>();

        public void AddTask(string name, Task.Priority priority, Task.Category category, Task.State state,
            DateTime registerDate, DateTime limitDate)
        {
            _tasks.Add(new Task(name,priority,category,state,registerDate,limitDate));
        }

        public override string ToString() => $"User {_name} have {_tasks.Count} tasks.";

        public void ShowAllTasks()
        {
            if (_tasks.Count > 0)
            {
                Task.PrepareForPrint();
                ShowTasks(_tasks);
            }
        }

        private void ShowTasks(List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                task.Print();
            }
        }

        public void ShowDelayedTasks()
        {
            var delayedTasks = _tasks.Where(task => task.IsDelayed()).ToList();
            if (delayedTasks.Count == 0) return;
            Task.PrepareForPrint();
            ShowTasks(delayedTasks);
        }

        //first approach for b)
        public void ShowTasksLowToHighPriority()
        {
            var lowPriorityTasks = _tasks.Where(task => task.TaskPriority == Task.Priority.Low).ToList();
            var mediumPriorityTasks = _tasks.Where(task => task.TaskPriority == Task.Priority.Medium).ToList();
            var highPriorityTasks = _tasks.Where(task => task.TaskPriority == Task.Priority.High).ToList();
            
            if (lowPriorityTasks.Count + mediumPriorityTasks.Count + highPriorityTasks.Count == 0) return;
            
            Task.PrepareForPrint();
            ShowTasks(lowPriorityTasks);
            ShowTasks(mediumPriorityTasks);
            ShowTasks(highPriorityTasks);
        }

        //second approach for b)
        public void ShowTasksWithPriority(Task.Priority priority)
        {
            var tasksToShow = _tasks.Where(task => task.TaskPriority == priority).ToList();
            
            if (tasksToShow.Count == 0 ) return;
            Console.WriteLine("Tasks with " + priority + " priority:");
            Task.PrepareForPrint();
            ShowTasks(tasksToShow);
        }

        //first approach for c)
        public void ShowTasksPersonalToWorkCategory()
        {
            var personalTasks = _tasks.Where(task => task.TaskCategory == Task.Category.Personal).ToList();
            var workTasks = _tasks.Where(task => task.TaskCategory == Task.Category.Work).ToList();
            
            if (personalTasks.Count + workTasks.Count == 0) return;
            
            Task.PrepareForPrint();
            ShowTasks(personalTasks);
            ShowTasks(workTasks);
        }
        
        //second approach for c)
        public void ShowTasksWithCategory(Task.Category category)
        {
            var tasksToShow = _tasks.Where(task => task.TaskCategory == category).ToList();
            
            if (tasksToShow.Count == 0 ) return;
            Console.WriteLine("Tasks on " + category + " category:");
            Task.PrepareForPrint();
            ShowTasks(tasksToShow);
        }

        //first approach for d)
        public void ShowTasksSortedByStateOfExecution()
        {
            var waitingTasks = _tasks.Where(task => task.TaskState == Task.State.Waiting).ToList();
            var inExecutionTasks = _tasks.Where(task => task.TaskState == Task.State.InExecution).ToList();
            var doneTasks = _tasks.Where(task => task.TaskState == Task.State.Done).ToList();
            
            if (waitingTasks.Count + inExecutionTasks.Count + doneTasks.Count == 0) return;
            
            Task.PrepareForPrint();
            ShowTasks(waitingTasks);
            ShowTasks(inExecutionTasks);
            ShowTasks(doneTasks);
        }
        
        //second approach for d)
        public void ShowTasksWithState(Task.State state)
        {
            var tasksToShow = _tasks.Where(task => task.TaskState == state).ToList();
            
            if (tasksToShow.Count == 0 ) return;
            Console.WriteLine("Tasks on state " + state);
            Task.PrepareForPrint();
            ShowTasks(tasksToShow);
        }

        public void RemoveDoneTasks()
        {
            _tasks = _tasks.Except(_tasks.Where(task => task.TaskState == Task.State.Done).ToList()).ToList();
        }
        
        public void RemovePersonalTasks()
        {
            _tasks = _tasks.Except(_tasks.Where(task => task.TaskCategory == Task.Category.Personal).ToList()).ToList();
        }
        
        public void RemoveLowPriorityTasks()
        {
            var lowPriorityTasks = _tasks.Where(task => task.TaskPriority == Task.Priority.Low).ToList();
            _tasks = _tasks.Except(lowPriorityTasks).ToList();
        }
    }
}