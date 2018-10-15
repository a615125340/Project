
//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------


namespace ProjectModel
{

using System;
    using System.Collections.Generic;
    
public partial class Task
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Task()
    {

        this.TaskDetails = new HashSet<TaskDetail>();

        this.TaskModifieds = new HashSet<TaskModified>();

        this.PreTasks = new HashSet<PreTask>();

    }


    public Nullable<int> WorkID { get; set; }

    public int TaskID { get; set; }

    public string TaskName { get; set; }

    public Nullable<System.DateTime> EstStartDate { get; set; }

    public Nullable<System.DateTime> EstEndDate { get; set; }

    public Nullable<System.DateTime> EstWorkTime { get; set; }

    public Nullable<System.DateTime> StartDate { get; set; }

    public Nullable<System.DateTime> EndDate { get; set; }

    public string WorkTime { get; set; }

    public Nullable<int> TaskStatusID { get; set; }

    public Nullable<int> EmployeeID { get; set; }

    public string Tag { get; set; }

    public string Description { get; set; }



    public virtual Employee Employee { get; set; }

    public virtual Status Status { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TaskDetail> TaskDetails { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TaskModified> TaskModifieds { get; set; }

    public virtual Work Work { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PreTask> PreTasks { get; set; }

    public virtual PreTask PreTask { get; set; }

}

}
