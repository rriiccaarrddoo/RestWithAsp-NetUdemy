using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestWithAspNetUdemy.HyperMedia
{
    public class PersonEnricher : ObjectContentResponseEnricher<Person>
    {

        protected override Task EnrichModel(Person content, IUrlHelper urlHelper)
        {
            var path = "api/people/v1";
            var url = new { controller = path, id = content.Id };
            var page = 1;
            var pagesize = 20;

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = urlHelper.Link("DefaultApi", $"{url}/{page}/{pagesize}"),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = "int"
            });

            return null;
        }
    }
}
