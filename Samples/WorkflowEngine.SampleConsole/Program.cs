// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowEngine.Core.Models;
using WorkflowEngine.Core.Services;
using WorkflowEngine.Core.Stores;
using WorkflowEngine.Core.Stores.InMemory;
using WorkflowEngine.Core;
using static System.Net.Mime.MediaTypeNames;

ConfigerWorkflowEngineData(args);
Console.ReadLine();

static async void ConfigerWorkflowEngineData(string[] args)
{
    IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<IWorkflowStore, InMemoryWorkflowStore>();
        services.AddScoped<IWorkflowActionStore, InMemoryWorkflowActionStore>();
        services.AddScoped<IWorkflowActivityStore, InMemoryWorkflowActivityStore>();
        services.AddScoped<IWorkflowActivityStepStore, InMemoryWorkflowActivityStepStore>();
    }).Build();

    #region Workflow Actions
    var actionList = new List<WorkflowAction>()
    {
        new WorkflowAction
        {
            WorkflowActionId  = 1,
            NameEn = "Send"
        },
        new WorkflowAction
        {
              WorkflowActionId  = 2,
            NameEn = "Accept"
        },
        new WorkflowAction
        {
              WorkflowActionId  = 3,
            NameEn = "Return"
        }, new WorkflowAction
        {
              WorkflowActionId  = 4,
             NameEn = "Reject"
        }
    };



    var actionService = host.Services.GetRequiredService<IWorkflowActionStore>();
    actionService.Add(actionList);

    var sendAction = actionService.GetById(1);
    var acceptAction = actionService.GetById(2);
    var returnedAction = actionService.GetById(3);
    var rejectAction = actionService.GetById(4);
    #endregion

    #region Workflow Activity

    var workflowService = host.Services.GetRequiredService<IWorkflowStore>();
    var workflow = await workflowService.GetWorkflowByIdAsync(1);


    var workflowActivityService = host.Services.GetRequiredService<IWorkflowActivityStore>();

    var activityList = new List<WorkflowActivity>()
    {
         new WorkflowActivity
        {
            NameEn = "Software Review Request Create",
            WorkflowActivityId = 1,
            IsComplete = false,
            IsStart = true,
            Workflow = workflow
        },
        new WorkflowActivity
        {
            NameEn = "Software Review Request Send",
            WorkflowActivityId = 2,
            IsComplete = false,
            IsStart = false,
            Workflow = workflow
        },
        new WorkflowActivity
        {
            NameEn = "Software Review Request Approved",
            WorkflowActivityId = 3,
            IsComplete = true,
            IsStart = false,
            Workflow = workflow
        },
        new WorkflowActivity
        {
            NameEn = "Software Review Request Reject",
            WorkflowActivityId = 4,
            IsComplete = true,
            IsStart = false,
            Workflow = workflow
        },
        new WorkflowActivity
        {
            NameEn = "Software Review Request Returned",
            WorkflowActivityId = 5,
            IsComplete = false,
            IsStart = false,
            Workflow = workflow
        },
    };


    workflowActivityService.Add(activityList);
    #endregion

    #region Workflow ActivitySteps

    var workflowActivityStepService = host.Services.GetRequiredService<IWorkflowActivityStepStore>();


    var sendActivity = await workflowActivityService.GetActivityByIdAsync(2);


    var activityStepList = new List<WorkflowActivityStep>()
    {
        new WorkflowActivityStep // This is tepming activity oe Status
        {
            WorkflowActivityStepId = 1,
            WorkflowActivity =await workflowActivityService.GetActivityByIdAsync(1),
            WorkflowAction = sendAction,
            NextWorkflowActivity = sendActivity,
            WithSendNotification = false,
            RequiredNotes = false,
            WithSendEmail = false,
        },

        new WorkflowActivityStep
        {
            WorkflowActivityStepId = 2,
            WorkflowActivity = sendActivity,
            WorkflowAction = returnedAction,
            NextWorkflowActivity = await workflowActivityService.GetActivityByIdAsync(1),
            WithSendNotification = true,
            RequiredNotes = true,
            WithSendEmail = true,
        },

        new WorkflowActivityStep
        {
            WorkflowActivityStepId = 3,
            WorkflowActivity = sendActivity,
            WorkflowAction = acceptAction,
            NextWorkflowActivity = null,
            WithSendNotification = true,
            RequiredNotes = true,
            WithSendEmail = true,
        },


        new WorkflowActivityStep
        {
            WorkflowActivityStepId = 3,
            WorkflowActivity = sendActivity,
            WorkflowAction = rejectAction,
            NextWorkflowActivity = null,
            WithSendNotification = true,
            RequiredNotes = true,
            WithSendEmail = true,
        },

    };
    workflowActivityStepService.Add(activityStepList);

    #endregion



    var workflowManager = new WorkflowManager(workflowActivityStepService);
    WorkflowContext workflowContext = new WorkflowContext()
    {
        ActionId = 4,
        CurrentActivityId = 3
    };

    var workflowResult = await workflowManager.Execute(workflowContext);

    Console.WriteLine($"IsValid# {workflowResult.IsValid}  ");
    if (workflowResult.WorkflowActivityStep.NextWorkflowActivity != null)
        Console.WriteLine($"Next Activity# {workflowResult.WorkflowActivityStep.NextWorkflowActivity.NameEn}");
    else
        Console.WriteLine("Workflow is completed here");
    
}
