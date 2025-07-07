public class Resume
{
    private string _name = "";
    private List<Job> _jobs = new List<Job>();

    public void SetName(string name)
    {
        _name = name;
    }

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}\n");
        foreach (Job job in _jobs)
        {
            job.DisplayJob();
        }
    }
}
