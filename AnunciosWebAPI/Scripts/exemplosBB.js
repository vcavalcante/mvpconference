//anunciante 1
//salvar novo anunciante
var model = new Model({
    Nome: "Victor Cavalcante",
    Email: "vcavalcante@lambda3.com.br",
    Telefone: "11-2386-1886"
});
model.save();
//salvar novo anunciante
var model = new Model({
    Nome: "Victor Cavalcante",
    Email: "vcavalcante@lambda3.com.br",
    Telefone: "11-2386-1886"
});
model.save();
//definindo o default
var Model = Backbone.Model.extend({
    urlRoot: "/api/anunciante",
    idAttribute: 'IdAnunciante',
    defaults: { Nome: 'João ninguem' }
});
var model = new Model({ "Email": "vcavalcante@lambda3.com.br" });
model.get("Nome");

//Collection 
var ModelAnunciante = Backbone.Model.extend({ idAttribute: 'IdAnunciante' });
var CollectionAnunciante = Backbone.Collection.extend({
    url: "/api/anunciante",
    model: ModelAnunciante
});
var collectionAnunciante = new CollectionAnunciante();
collectionAnunciante.fetch();
collectionAnunciante.length;
collectionAnunciante.toJSON();


//selecionando collections
collectionAnunciante.where({ Nome: 'Renato' });
collectionAnunciante.filter(function (x) {
    if (x.get("Nome").indexOf("R") == 0) return x;
});
