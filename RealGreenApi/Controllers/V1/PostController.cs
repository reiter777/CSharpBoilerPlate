using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealGreenApi.Contracs.V1;
using RealGreenApi.Contracs.V1.Request;
using RealGreenApi.Contracs.V1.Response;
using RealGreenApi.Domain;
using RealGreenApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGreenApi.Controllers.V1
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;


        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _postService.GetPostById(postId);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult Update([FromRoute] Guid postId, UpdatePostRequest request)
        {
            var post = new Post
            {
                Id= postId,
                Name=request.Name
            };

            var updated = _postService.UpdatePost(post);
            
            if(updated)
            return Ok(post);

            return NotFound();
        }


        [HttpDelete(ApiRoutes.Posts.Delete)]
        public IActionResult Delete([FromRoute] Guid postId)
        {

            var deleted = _postService.DeletePost(postId);

            if (deleted)
                return NoContent();

            return NotFound();
        }




        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };

            if (post.Id != Guid.Empty)
                post.Id = Guid.NewGuid();

            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };

            return Created(locationUri, response);
        }



    }
}
