//document.getElementById('btnIniciarSesion').addEventListener('click', iniciarSesion);

function iniciarSesion(event)
{
    event.preventDefault();

    let usuario = document.getElementById("Usuario").value;//("<%=Usuario.ClientID%>").value;
    let contrasena = document.getElementById("Contrasena").value;//("<%=Contrasena.ClientID%>").value;
    //if (usuario == "" || contrasena == "")
    //{
    //    Swal.fire({
    //        title: 'Error', // E.g., 'Success' or 'Error'
    //        text: 'Complete los campos', // Your message from TempData
    //        icon: 'error', // E.g., 'success', 'error', 'info', 'warning'
    //        confirmButtonText: 'OK'
    //    });
    //}

    $.ajax({
        url: 'Acceso/IniciarSesion',
        type: 'POST',
        data: { strUsuario: usuario, strContrasena: contrasena },
        success: function (resultado)
        {
            debugger;
            if (resultado.trim() == 'ok') {

                Swal.fire({
                    heightAuto: false,
                    title: 'Exito', // E.g., 'Success' or 'Error'
                    text: resultado.trim(), // Your message from TempData
                    icon: 'success', // E.g., 'success', 'error', 'info', 'warning'
                    confirmButtonText: 'OK'//,
                    
                });
            }
            else
            {
                debugger;
                Swal.fire({
                    heightAuto: false,

                    title: 'Error', // E.g., 'Success' or 'Error'
                    text: resultado.trim(), // Your message from TempData
                    icon: 'error', // E.g., 'success', 'error', 'info', 'warning'
                    confirmButtonText: 'OK'
                });
            }
        },
        error: function (resultadoError)
        {
            debugger;
        }

    });
    return false;
}