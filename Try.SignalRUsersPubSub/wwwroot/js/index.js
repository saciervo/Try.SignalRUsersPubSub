"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub",
        {
            accessTokenFactory: function () {
                // JWT => unique_name: "johnny", valid until Apr 09, 2023
                return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImpvaG5ueSIsIm5iZiI6MTU4MTA3MTUxNCwiZXhwIjoxNTgxNjc2MzE0LCJpYXQiOjE2ODEwNzE1MTR9.7K6zl8a0uxpN2i2paxwuVsMRtSaKFgoJHpi_r2TzXx4";
            }
        })
    .build();

connection.on("jobCompleted",
    function (jobId) {
        $("#pnl-alerts").append('<div class="alert alert-secondary" role="alert">Congrats! Task completed (Job:' + jobId + ')</div >');
    });

connection.start()
    .catch(function (err) {
        return console.error(err.toString());
    });

$(function () {
    $("#btn-start-job").click(function () {
        $.post("/home/startjob");
    });
})