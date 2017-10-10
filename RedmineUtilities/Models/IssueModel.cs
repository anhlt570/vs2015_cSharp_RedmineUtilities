using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace RedmineUtilities.Models.issue_models
{
    public class PrimitiveModel:DbContext
    {
        public int id { get; set; }
    }

    public class BasicModel : PrimitiveModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CustomField : BasicModel
    {
        public string value { get; set; }
    }

    public class Issue
    {
        public int id { get; set; }
        public BasicModel project { get; set; }
        public BasicModel tracker { get; set; }
        public BasicModel status { get; set; }
        public BasicModel priority { get; set; }
        public BasicModel author { get; set; }
        public BasicModel fixed_version { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public string start_date { get; set; }
        public int done_ratio { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
        public int? story_points { get; set; }
        public BasicModel assigned_to { get; set; }
        public string due_date { get; set; }
        public PrimitiveModel parent { get; set; }
        public BasicModel category { get; set; }
        public float estimated_hours { get; set; }
    }

    public class IssuesResponse
    {
        public List<Issue> issues { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }
}
