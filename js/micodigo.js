function verAlerta(ti, msj, tipo) {
    Swal.fire({
        title: ti,
        text: msj,
        icon: tipo,
        confirmButtonText: 'Continuar'
    });
}