using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.interfaces;
using CRMSystem.DAL.interfaces;
using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class LeadService : ILeadService
{
    private readonly ILeadRepository _repository;

    public LeadService(ILeadRepository repository)
    {
        _repository = repository;
    }

    public void Create(LeadDTO dto)
    {
        var lead = new Lead
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Source = dto.Source,
            CreatedAt = DateTime.Now
        };
        _repository.Add(lead);
    }

    public List<LeadDTO> Get()
    {
        var leads = _repository.GetAll();
        return leads.Select(l => new LeadDTO
        {
            Id = l.Id,
            FullName = l.FullName,
            Email = l.Email,
            Source = l.Source,
            CreatedAt = l.CreatedAt
        }).ToList();
    }

    public LeadDTO Get(int id)
    {
        var lead = _repository.GetById(id);
        if (lead == null) return null;

        return new LeadDTO
        {
            Id = lead.Id,
            FullName = lead.FullName,
            Email = lead.Email,
            Source = lead.Source,
            CreatedAt = lead.CreatedAt
        };
    }

    public void Update(LeadDTO dto)
    {
        var lead = _repository.GetById(dto.Id);
        if (lead == null) throw new Exception("Lead not found");

        lead.FullName = dto.FullName;
        lead.Email = dto.Email;
        lead.Source = dto.Source;

        _repository.Update(lead);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
