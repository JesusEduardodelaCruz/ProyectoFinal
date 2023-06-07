$(() => {
    $('#modalDetalle').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var titulo = button.data('titulo');
        var descripcion = button.data('descripcion');
        var imagen = button.data('imagen');

        var modal = $(this);
        modal.find('.modal-title').text(titulo);
        modal.find('#modalDescripcion').text(descripcion);
        modal.find('#modalImagen').attr('src', imagen);
    });
});