function seleccionado(){
    var opt = $('#opcion').val();
    
   // alert(opt);
    if(opt=="cat"){
        $('#categoria').show();
        $('#subcategoria').hide();
        $('#producto').hide();
    }else{
        if(opt=="subcat"){
            $('#categoria').hide();
            $('#subcategoria').show();
            $('#producto').hide();
        }else{
            $('#categoria').hide();
            $('#subcategoria').hide();
            $('#producto').show();
        }
    }
}


	
	$(document).ready(function() {
    var table = $('#example').DataTable( {
        fixedHeader: {
        
        }
    } );
} );


	$(document).ready(function() {
    var table = $('#example1').DataTable( {
        fixedHeader: {
            header: true,	
            footer: true
        }
    } );
} );