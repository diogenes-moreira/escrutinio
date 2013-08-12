viewModel = function CargaMesaViewModel() {
    var self = this;
    self.escrutinios = new ko.observableArray();
    self.numero = new ko.observable();
    self.mesa = new ko.observable();
    self.listas = new ko.observable();
    self.categorias = new ko.observableArray();

    self.Initialize= function() {
        //$.get(path+'/listas', self.listas);
        $.get(path+'/categorias', self.listas);
    };
};


//view.Initialze();


//ko.applyBindings(CargaMesaViewModel);