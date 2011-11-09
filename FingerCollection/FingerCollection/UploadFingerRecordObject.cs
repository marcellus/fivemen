using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FingerCollection
{
    [SimpleTable("table_upload_finger_record")]
    [Alias("已上传的指纹记录")]
    public class UploadFingerRecordObject : LocalFingerRecordObject
    {
    }
}
