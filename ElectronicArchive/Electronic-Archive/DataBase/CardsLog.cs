//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Electronic_Archive.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardsLog
    {
        public int ID_log { get; set; }
        public string ДН { get; set; }
        public string Старые_значения { get; set; }
        public string Новые_значения { get; set; }
        public string Пользователь { get; set; }
        public string Дата_изменения { get; set; }
    }
}