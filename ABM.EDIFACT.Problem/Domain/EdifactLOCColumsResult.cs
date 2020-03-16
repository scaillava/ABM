using System;
using System.Collections.Generic;
using System.Text;

namespace ABM.EDIFACT.Problem.Domain
{
    public class EdifactLOCColumsResult
    {
        public EdifactLOCColumsResult(string[] secondColumn, string[] thirdColumn)
        {
            this.secondColumn = secondColumn;
            this.thirdColumn = thirdColumn;
        }
        public string[] secondColumn { get; set; }
        public string[] thirdColumn { get; set; }



        //Need this to objects compare.
        public override bool Equals(object obj)
        {
            if (!(obj is EdifactLOCColumsResult))
                return false;

            EdifactLOCColumsResult edifactLOCColumsResult = (EdifactLOCColumsResult)obj;
            if ((this.secondColumn == edifactLOCColumsResult.secondColumn) && (this.thirdColumn == edifactLOCColumsResult.thirdColumn))
                return true;
            else
                return false;

        }
    }
}

