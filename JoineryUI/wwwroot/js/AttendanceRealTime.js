

$(() => {
    LoadProdData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadEntries", function () {
        LoadEntryData();
        

    })




    LoadEntryData();


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

                            <td>Pon 18.01</td>
                            <td> 8:00</td>
                            <td>16:07</td>
                            <td class="desc">${v.name}</td>
                            <td>8h 07</td>


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






