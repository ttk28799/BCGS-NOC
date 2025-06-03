using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GiaoBanTrucNOC.SaveLoad
{
    public class Device
    {
        public Device(Guid id, DeviceLocation location, string name, DeviceIssue issue, string note)
        {
            ID = id;
            Location = location;
            Name = name;
            Issue = issue;
            Note = note;
        }

        [Browsable(false)]
        public Guid ID { get; set; } = Guid.NewGuid();

        [DisplayName("Vị trí")]
        public DeviceLocation Location { get; set; } = new DeviceLocation();

        [DisplayName("Tên thiết bị")]
        public string Name { get; set; } = string.Empty;

        public class DeviceIssue
        {
            public List<string> IssueList { get; set; } = new List<string>();

            public override string ToString()
            {
                return string.Join(", ", IssueList);
            }
        }

        [DisplayName("Lỗi")]
        public DeviceIssue Issue { get; set; } = new DeviceIssue();

        [DisplayName("Ghi chú")]
        public string Note { get; set; } = string.Empty;

        public class DeviceLocation
        {
            public string Region { get; set; } = string.Empty;
            public string Rack { get; set; } = string.Empty;

            public override string ToString() => $"RACK{Rack}";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}