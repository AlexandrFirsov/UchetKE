//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Translate_
    {
        public int id { get; set; }
        public System.DateTime date_translate { get; set; }
        public Nullable<int> sender { get; set; }
        public Nullable<int> receiver { get; set; }
    
        public virtual respons_person respons_person { get; set; }
        public virtual respons_person respons_person1 { get; set; }
    }
}
