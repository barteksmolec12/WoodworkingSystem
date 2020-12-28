

//$(() => {
//    LoadProdData();
//    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
//    connection.start();
//    connection.on("LoadProducts", function () {
//        LoadProdData();
//        console.log('test czy dziala');

//    })
//    let elem = 0;

   

//    LoadProdData();
    

//    function LoadProdData() {

        
//        var div = '';
      
//        $.ajax(

//            {

//                url: '/PositionsState/GetMachines',
//                method: 'GET',
//                dataType: 'json',
//                success: (result) => {

                 
                 
//                    $.each(result, (k, v) => {

//                        //    countArray = result.length;

//                        //if (elem <= countArray) {
//                        if (elem == 0)
//                        {


//                            if (v.state == 'Wolne') {

//                                div += ` 
//                                           <div class="col-33">

//                                                <div class="block">
//                                                    <h5 style="color:green;">${v.name}</h5>
//                                                    <img style="width:90%;border-radius:3px;margin-bottom:6px;" src="${v.image}" alt="Girl in a jacket">
//                                                        <h5 style="text-align:center;">${v.applicationUser.name}</h5>
//                                                    <a id="buttonInBlock" href='../PositionsState/ChangeStatusMachine?id=${v.id}' >Zajmij maszynę</a>
//                                                </div>
    
//                                            </div>`


//                                  }
//                            else
//                            {
//                                div += ` 
//                                           <div class="col-33">

//                                                <div class="block">
//                                                    <h5 style="color:green;">${v.name}</h5>
//                                                    <img style="width:90%;border-radius:3px;margin-bottom:6px;" src="${v.image}" alt="Girl in a jacket">
//                                                        <h5 style="text-align:center;">${v.applicationUser.name}</h5>
//                                                    <a id="buttonBad" href='../PositionsState/ChangeStatusMachine?id=${v.id}' >Maszyna zajęta</a>
//                                                </div>
    
//                                            </div>`


//                            }
//                        }
                       

//                    })
//                    if (elem < 1) {
//                        $("#hehe").append(div);
//                        elem = elem + 1;
//                    }
//                },

//                error: (error) => {
//                    console.log(error)
//                }
//            })
//    }




//});
//function someFunction() {
//    alert('Mam')
//}






