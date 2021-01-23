

$(() => {
    LoadProdData();
    LoadEntryData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadProducts", function () {
        //LoadProdData();
        LoadProdData();
        console.log('Machines');

    })
    connection.on("LoadEntries", function () {
        //LoadProdData();
        LoadEntryData();
        console.log('Entries');

    })
    //let elem = 0;
    
    //var doActions= true;

    ////LoadProdData();
    

    function LoadProdData() {
        doActions = true;
        var div = '';
        let user = '';
        $.ajax(

            {

                url: '/PositionsState/GetMachines',
                method: 'GET',
                dataType: 'json',
                success: (result) => {



                    $.each(result, (k, v) => {

                        //    countArray = result.length;

                        //if (elem <= countArray) {
                        if (doActions == true) {

                            //get LoggedUserId
                            if (user == '') {

                                user = getLoggedUser();
                            }

                            //if LoggedUserId == v.applicationUser.Id
                            if (user == v.woodmakerId) {
                                div += `  <div id="elem"><h5 style="color:green;">${v.name}</h5><img src="${v.image}" alt="Machine"><a style="" id="buttonWarning"  href='javascript:postMethod(${v.id});'><strong>Zwolnij maszynę</strong></a></div>`
                            }
                            else {

                                // div += ' <div id="elem"><h5 style="color:black;">${v.name}</h5><img src="${v.image}" alt="MachineBad"><a style="" id="buttonBad"  href='javascript:postMethod(${v.id});'><strong> Zwolnij maszynę </strong></a></div>'

                                //else
                                if (v.state == 'Zajęte') {
                                    div += `  <div id="elem"><h5 style="color:black;">${v.name}</h5><img src="${v.image}" alt="MachineBad"><a style="pointer-events: none;" id="buttonBad"  href='javascript:postMethod(${v.id});'>Zajęte przez <strong>${v.applicationUser.name}</strong></a></div>`
                                }



                                else {
                                    div += `  <div id="elem"><h5 style="color:green;">${v.name}</h5><img src="${v.image}" alt="Machine"><a style="" id="buttonInBlock"  href='javascript:postMethod(${v.id});'><strong>Zajmij maszynę</strong></a></div>`
                                }
                            }
                            //

                        }


                    })
                    if (doActions==true) {
                        $(".auto-grid").html(div);
                        doActions = false;


                    }

                },

                error: (error) => {
                    console.log(error)
                }

            });
     
      
    }

    function LoadEntryData() {

        var tr = '';
        $.ajax(
            {

                url: '/Attendance/GetEntries',
                method: 'GET',
                success: (result) => {

                    $.each(result, (k, v) => {


                        tr += `
                        <tr class="tr-shadow">

                            <td>${v.dayOfEntry}</td>
                            <td> ${v.timeIn}</td>
                            <td>${v.timeOut}</td>
                            <td class="desc">${v.applicationUser.name}</td>
                            <td style="position: relative;"><button type="button" class="btn btn-success">W pracy</button></td>


                        </tr>`



                    })
                    $("#tableBody").html(tr);
                },
                error: (error) => {
                    console.log(error)
                }
            })
    }


});




function postMethod(machineId) {
    $.post("/PositionsState/ChangeStatusMachine", { id: machineId});
   
}


function getLoggedUser() {
    var result = null;
    var scriptUrl = "PositionsState/GetLoggedUser";
    $.ajax({
        url: scriptUrl,
        type: 'get',
        dataType: 'html',
        async: false,
        success: function (data) {
            result = data;
        }
    });
    return result;
}




