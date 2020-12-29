

$(() => {
    LoadProdData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadProducts", function () {
        LoadProdData();
        LoadProdData();
        console.log('test czy dziala');

    })
    let elem = 0;

   

    LoadProdData();
    

    function LoadProdData() {

        
        var div = '';
      
        $.ajax(

            {

                url: '/PositionsState/GetMachines',
                method: 'GET',
                dataType: 'json',
                success: (result) => {

                 
                 
                    $.each(result, (k, v) => {

                        //    countArray = result.length;

                        //if (elem <= countArray) {
                        //if (elem == 0)
                        //{


                            if (v.state == 'Zajęte')
                            {
                                div += `  <div id="elem"><h5 style="color:black;">${v.name}</h5><img src="${v.image}" alt="MachineBad"><a style="" id="buttonBad"  href='javascript:postMethod(${v.id});'>Zajęte przez <strong>${v.applicationUser.name}</strong></a></div>`
                            }             


                                  
                            else
                            {
                                div += `  <div id="elem"><h5 style="color:black;">${v.name}</h5><img src="${v.image}" alt="Machine"><a style="" id="buttonInBlock"  href='javascript:postMethod(${v.id});'><strong>Zajmij maszynę</strong></a></div>`
                            }            


                            
                        //}
                       

                    })
                    //if (elem < 1) {
                        $(".auto-grid").append(div);
                        //elem = elem + 1;
                      
                    //}

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





