using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeUI
{
    public interface EFOperations
    {
        void AddoneRecord();
        void AddMultipleRecords();

        void GetOneRecord();
        void GetOneRecordWithSpecficCondition();
        void GetOneRecordWirhitRelatedData();
        void  GetOneRecordWithRelatedDataWithspecficCondition();

        void GetMultipleRecordsWithRelateddatWithSpecficCondition();
        void  GetMultipleRecordsOrderbySpecficProperty ();
        void  GetMultipleRecordsOrderbySpecficRelatedDataProperty();

        void GetdatafromMultiplerelationships();

        void  ModifyOneRecord();
        void  ModifyMultipleRecords();
        void  ModifyOneRecordSpecficRelatedData();


    }
}
