//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClubManagement.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int ID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> SectionID { get; set; }
        public Nullable<int> TeacherID { get; set; }
    
        public virtual SectionSchedule SectionSchedule { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
