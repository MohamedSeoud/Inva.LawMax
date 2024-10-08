﻿using System;

namespace Inva.LawMax.Application.Contracts.Dtos
{
    public class HearingDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid CaseId { get; set; }
        public CaseDto Case { get; set; }
        public string Decision { get; set; }

    }
}
