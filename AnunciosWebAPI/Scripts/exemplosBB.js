//anunciante 1
var Model = Backbone.Model.extend({ urlRoot: "/api/anunciante", idAttribute: 'IdAnunciante' });
var model = new Model({ idAttribute: 1 });
model.fetch();

//salvar novo anunciante
var model = new Model({ Nome: "Victor Cavalcante", "Email": "vcavalcante@lambda3.com.br" });
model.save();

//definindo o default
var Model = Backbone.Model.extend({ urlRoot: "/api/anunciante", idAttribute: 'IdAnunciante', defaults: { Nome: 'João ninguem' } });
var model = new Model({ "Email": "vcavalcante@lambda3.com.br" });
model.get("Nome");

//criando collection
var Anunciante = Backbone.Model.extend({ idAttribute: 'IdAnunciante' });
var Anunciantes = Backbone.Collection.extend({ model: Anunciante, url: '/api/anunciante' });
var anunciantes = new Anunciantes();
anunciantes.fetch()
anunciantes.toJSON()

//where
anunciantes.where({ Nome: 'Maurice' })