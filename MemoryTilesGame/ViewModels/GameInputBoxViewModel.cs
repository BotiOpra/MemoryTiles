using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTilesGame.ViewModels
{
    public class GameInputBoxViewModel
    {
        public int RowValue { get; set; }
        public int ColumnValue { get; set; }
    }

    public class GameInitMessage
    {
        public string RowString { get; set; }
        public string ColumnString { get; set; }
    }
}
