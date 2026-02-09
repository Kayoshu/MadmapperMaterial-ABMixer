/*{
    "CREDIT": "IMIMOT, adapted by Jason Beyers",
    "DESCRIPTION": "Transitions input image to texture, with animated mix controls. From http://transitions.glsl.io/transition/b86b90161503a0023231",
    "VSN": "1.4",

    "INPUTS": [

        {
            "LABEL": "Mix/Mix",
            "NAME": "mat_mix",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.0
        },
        {
            "LABEL": "Mix/Transition",
            "NAME": "mat_transition",
            "TYPE": "long",
            "VALUES": [
					"CrossZoom", 
					"Hexagons",
					"ButterflyWaves",
					"GlitchMemories",
					"Squares",
				],
            "DEFAULT": "Hexagons",
            "FLAGS": ["generate_as_define"]
        },
        {
            "LABEL": "Mix/CrossZoom Scale",
            "NAME": "mat_crosszoomstrength",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 4.0,
            "DEFAULT": 1.0
        },
        {
            "LABEL": "Mix/Hexagons Size",
            "NAME": "mat_horizontalHexagons",
            "TYPE": "float",
            "MIN": 2,
            "MAX": 75,
            "DEFAULT": 16
        },
		  {
            "LABEL": "Mix/Butterfly Waves",
            "NAME": "mat_butterflywaves",
            "TYPE": "int",
            "MIN": 2,
            "MAX": 20,
            "DEFAULT": 5
        },
        {
            "LABEL": "Mix/Butterfly ColorSep",
            "NAME": "mat_butterflycolorsep",
            "TYPE": "float",
            "MIN": 0,
            "MAX": 1,
            "DEFAULT": 0.3
        },
        {
            "LABEL": "Mix/Squares X",
            "NAME": "mat_rngsquares_x",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 50.0,
            "DEFAULT": 20
        },
        {
            "LABEL": "Mix/Squares Y",
            "NAME": "mat_rngsquares_y",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 25.0,
            "DEFAULT": 10
        },
        {
            "LABEL": "Mix/Squares Smooth",
            "NAME": "mat_rngsquares_smooth",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.5
        },
        {
            "LABEL": "Target/Texture A",
            "NAME": "mat_input_imageA",
            "TYPE": "image",
        },
        {
            "LABEL": "Target/Aspect",
            "NAME": "mat_texture_aspect",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 2.0,
            "DEFAULT": 1.0
        },
        {
            "LABEL": "Target/Scale",
            "NAME": "mat_texture_scale",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 4.0,
            "DEFAULT": 1.0
        },
        {
            "LABEL": "Target/Texture B",
            "NAME": "mat_input_imageB",
            "TYPE": "image",
        },
        {
            "LABEL": "Animate/Animate",
            "NAME": "mat_animate_param",
            "TYPE": "bool",
            "DEFAULT": false,
            "FLAGS": "button"
        },
        {
            "LABEL": "Animate/Floor",
            "NAME": "mat_param_floor",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.0
        },
        {
            "LABEL": "Animate/Type",
            "NAME": "mat_param_move",
            "TYPE": "long",
            "VALUES": [
					"Fixed Rate", 
					"Fixed Rate With Audio",
					"Fixed Rate With Bass Audio",
					"Fixed Rate With Treble Audio",
					"Audio", 
					"Bass Audio", 
					"Treble Audio",
				],
            "DEFAULT": "Fixed Rate",
            "FLAGS": "generate_as_define"
        },
        {
            "LABEL": "Animate/Speed",
            "NAME": "mat_param_speed",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 4.0,
            "DEFAULT": 0.5
        },
        {
            "LABEL": "Animate/BPM Sync",
            "NAME": "mat_param_bpm_sync",
            "TYPE": "bool",
            "DEFAULT": true,
            "FLAGS": "button"
        },
        {
            "LABEL": "Animate/Shape",
            "NAME": "mat_param_steady_shape",
            "TYPE": "long",
            "VALUES": ["In","Out","Smooth"], 
				"DEFAULT": "Smooth"
        },
        {
            "Label": "Animate/Offset",
            "NAME": "mat_param_offset",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.0
        },
        {
            "LABEL": "Animate/Decay",
            "NAME": "mat_param_decay",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.0
        },
        {
            "LABEL": "Animate/Release",
            "NAME": "mat_param_release",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 1.0
        },

        {
            "NAME": "mat_spectrum",
            "TYPE": "audioFFT",
            "SIZE": 16,
            "ATTACK": 0.0,
            "DECAY": 0.0, //0.0
            "RELEASE": 0.4 //0.2
        },
        {
            "NAME": "mat_spectrum_16_decay",
            "TYPE": "audioFFT",
            "SIZE": 16,
            "ATTACK": 0.0,
            "DECAY": 0.4,
            "RELEASE": 0.0
        },
        {
            "Label": "Audio Sense/Master",
            "NAME": "mat_ABmaster_scale",
            "TYPE": "float",
            "DEFAULT": 1.0,
            "MIN": 0.0,
            "MAX": 10.0
        },
        {
            "Label": "Audio Sense/Bass",
            "NAME": "mat_bass_level",
            "TYPE": "float",
            "DEFAULT": 1.0,
            "MIN": 0.0,
            "MAX": 3.0
        },
        {
            "Label": "Audio Sense/Midrange",
            "NAME": "mat_medium_level",
            "TYPE": "float",
            "DEFAULT": 1.0,
            "MIN": 0.0,
            "MAX": 3.0
        },
        {
            "Label": "Audio Sense/Treble",
            "NAME": "mat_treble_level",
            "TYPE": "float",
            "DEFAULT": 1.0,
            "MIN": 0.0,
            "MAX": 3.0
        },

    ],
    "GENERATORS": [
        {
            "NAME": "mat_param_time_source",
            "TYPE": "animator",
            "PARAMS": {
                "speed": "mat_param_speed",
                "speed_curve":2,
                "bpm_sync": "mat_param_bpm_sync",
                "shape": "mat_param_steady_shape",
                "link_speed_to_global_bpm":true
            }
        },
    ]

}*/

#include "MadCommon.glsl"

float ratiofx = RENDERSIZE.x / RENDERSIZE.y;


// main crossfade function used for most transitions

vec4 CrossFade(in vec2 uv, in float dissolve) {
    vec2 uv_target = uv;
    uv_target -= vec2(0.5);
    uv_target.x *= mat_texture_aspect;
	
	 // to try auto fit B input into ratio from A input
    // uv_target.y /= mat_texture_aspect;

    uv_target *= mat_texture_scale;
    uv_target += vec2(0.5);

    return mix(IMG_NORM_PIXEL(mat_input_imageA, uv), IMG_NORM_PIXEL(mat_input_imageB, uv_target), dissolve);
}


// CrossZoom Transition

float Linear_ease(in float begin, in float change, in float duration, in float time) {
    return change * time / duration + begin;
}

float Exponential_easeInOut(in float begin, in float change, in float duration, in float time) {
    if (time == 0.0)
        return begin;
    else if (time == duration)
        return begin + change;
    time = time / (duration / 2.0);
    if (time < 1.0)
        return change / 2.0 * pow(2.0, 10.0 * (time - 1.0)) + begin;
    return change / 2.0 * (-pow(2.0, -10.0 * (time - 1.0)) + 2.0) + begin;
}

float Sinusoidal_easeInOut(in float begin, in float change, in float duration, in float time) {
    return -change / 2.0 * (cos(PI * time / duration) - 1.0) + begin;
}

float random(in vec3 scale, in float seed, in vec2 coord) {
    /* random number between 0 and 1, use the fragment position for randomness */
    return fract(sin(dot(vec3(coord.x, coord.y, 1.) + seed, scale)) * 43758.5453 + seed);
}

vec4 CrossZoomTransition(in vec2 uv, in float modulated_amount) {
    vec2 texCoord = uv;
    vec4 fx_out;

    // Linear interpolate center across center half of the image
    vec2 center = vec2(Linear_ease(0.25, 0.5, 1.0, modulated_amount), 0.5);
    float dissolve = Exponential_easeInOut(0.0, 1.0, 1.0, modulated_amount);

    // Mirrored sinusoidal loop. 0->strength then strength->0
    float strength = Sinusoidal_easeInOut(0.0, mat_crosszoomstrength * 0.4, 0.5, modulated_amount);

    vec4 color = vec4(0.0);
    float total = 0.0;
    vec2 toCenter = center - texCoord;
    /* randomize the lookup values to hide the fixed number of samples */
    float offset = random(vec3(12.9898, 78.233, 151.7182), 0.0, uv);

    for (float t = 0.0; t <= 40.0; t++) {
        float percent = (t + offset) / 40.0;
        float weight = 4.0 * (percent - percent * percent);
        color += CrossFade(texCoord + toCenter * percent * strength, dissolve) * weight;
        total += weight;
    }
    fx_out = vec4(color / total);
	 return fx_out;
}


// Hexagonalize Transition

struct Hexagon {
	  float q;
	  float r;
	  float s;
};

Hexagon createHexagon(float q, float r){
	  Hexagon hex;
	  hex.q = q;
	  hex.r = r;
	  hex.s = -q - r;
	  return hex;
}

Hexagon roundHexagon(Hexagon hex){
	  float q = floor(hex.q + 0.5);
	  float r = floor(hex.r + 0.5);
	  float s = floor(hex.s + 0.5);
	  float deltaQ = abs(q - hex.q);
	  float deltaR = abs(r - hex.r);
	  float deltaS = abs(s - hex.s);
	
	  if (deltaQ > deltaR && deltaQ > deltaS)
	    q = -r - s;
	  else if (deltaR > deltaS)
	    r = -q - s;
	  else
	    s = -q - r;
	
	  return createHexagon(q, r);
}

Hexagon hexagonFromPoint(vec2 point, float size) {
	  point.y /= ratiofx;
	  point = (point - 0.5) / size;
	  
	  float q = (sqrt(3.0) / 3.0) * point.x + (-1.0 / 3.0) * point.y;
	  float r = 0.0 * point.x + 2.0 / 3.0 * point.y;
	
	  Hexagon hex = createHexagon(q, r);
	  return roundHexagon(hex);
}

vec2 pointFromHexagon(Hexagon hex, float size) {
	  float x = (sqrt(3.0) * hex.q + (sqrt(3.0) / 2.0) * hex.r) * size + 0.5;
	  float y = (0.0 * hex.q + (3.0 / 2.0) * hex.r) * size + 0.5;
	  
	  return vec2(x, y * ratiofx);
}

vec4 HexagonalizeTransition(in vec2 uv, in float modulated_amount) {
    vec4 fx_out;
	 vec2 texCoord;	

	 float dist = 2.0 * min(modulated_amount, 1.0 - modulated_amount);
	 dist = 50 > 0 ? ceil(dist * float(50)) / float(50) : dist;

	 float size = (sqrt(3.0) / 3.0) * dist / mat_horizontalHexagons;
	 texCoord = dist > 0.0 ? pointFromHexagon(hexagonFromPoint(uv, size), size) : texCoord;

	 // hexagonalize only return first pixel uv at full amount
	 if (modulated_amount == 0) { texCoord = uv;}
	 if (modulated_amount == 1) { texCoord = uv;}

	 fx_out = CrossFade(texCoord, modulated_amount);
	 return fx_out;
}


// Butterfly Waves Transition

float compute(in vec2 p, in float progress, in vec2 center) {
	vec2 o = p * sin(progress * 2) - center;
	vec2 h = vec2(0.5, 0.0);
	// butterfly polar function (don't ask me why this one :))
	float theta = acos(dot(o, h)) * mat_butterflywaves;
	return (exp(cos(theta)) - 2. * cos(4. * theta) + pow(sin((2. * theta - PI) / 24.), 5.)) / 10.;
}

vec4 ButterflyTransition(in vec2 uv, in float modulated_amount) {
	vec2 p = uv.xy / vec2(1.0).xy;
	float inv = 1. - modulated_amount;
	vec2 dir = p - vec2(.5);
	float dist = length(dir);
	float disp = compute(p, modulated_amount, vec2(0.5, 0.5));

	vec4 texTo = IMG_NORM_PIXEL(mat_input_imageB, p + inv * disp);
	vec4 texFrom = vec4(
		IMG_NORM_PIXEL(mat_input_imageA, p + modulated_amount * disp * (1.0 - mat_butterflycolorsep)).r,
		IMG_NORM_PIXEL(mat_input_imageA, p + modulated_amount * disp).g,
		IMG_NORM_PIXEL(mat_input_imageA, p + modulated_amount * disp * (1.0 + mat_butterflycolorsep)).b,
		mix(IMG_NORM_PIXEL(mat_input_imageA, p + modulated_amount * disp), IMG_NORM_PIXEL(mat_input_imageB, p + modulated_amount * disp), modulated_amount).a
	);
	return texTo * modulated_amount + texFrom * inv;
}


// Glitch Memories Transition

vec4 GlitchMemoriesTransition(in vec2 uv, in float modulated_amount) {
	vec2 block = floor(uv.xy / vec2(16));
	vec2 uv_noise = block / vec2(64);
	uv_noise += floor(vec2(modulated_amount) * vec2(1200.0, 3500.0)) / vec2(64);
	vec2 dist = modulated_amount > 0.0 ? (fract(uv_noise) - 0.5) * 0.3 *(1.0 - modulated_amount) : vec2(0.0);
	vec2 red = uv + dist * 0.2;
	vec2 green = uv + dist * .3;
	vec2 blue = uv + dist * .5;

	return vec4(
		mix(IMG_NORM_PIXEL(mat_input_imageA, red), IMG_NORM_PIXEL(mat_input_imageB, red), modulated_amount).r,
		mix(IMG_NORM_PIXEL(mat_input_imageA, green), IMG_NORM_PIXEL(mat_input_imageB, green), modulated_amount).g,
		mix(IMG_NORM_PIXEL(mat_input_imageA, blue), IMG_NORM_PIXEL(mat_input_imageB, blue), modulated_amount).b,
// if texture B has alpha channel mixe faster (slider ?)
		mix(IMG_NORM_PIXEL(mat_input_imageA, uv), IMG_NORM_PIXEL(mat_input_imageB, uv + dist * 0.1), modulated_amount * 1.25).a
	);
}


// Squares Transition
float rand (vec2 co) {
  return fract(sin(dot(co.xy ,vec2(12.9898, 78.233))) * 43758.5453);
}

vec4 RANDSquaresTransition(in vec2 uv, in float modulated_amount) {
	vec4 fx_out;

	float r = rand(floor(vec2(mat_rngsquares_x, mat_rngsquares_y) * uv));
	float m = smoothstep(0.0, -mat_rngsquares_smooth, r - (modulated_amount * (1.0 + mat_rngsquares_smooth)));

	fx_out = CrossFade(uv, m);
	return fx_out;

}



// FX output
vec4 materialColorForPixel(vec2 texCoord)
{
    vec2 uv = texCoord;
    vec4 out_color;

    float amount = mat_mix; // Scaled input amount
    float modulated_amount;  // Final FX multiplier

    if (mat_animate_param) {
        // Audio detection
        float audio_value = 0.0;
        float bass_value = 0.3 * mat_ABmaster_scale * mat_bass_level * IMG_NORM_PIXEL(mat_spectrum,vec2(0.17,0)).r;
        float medium_value = 0.3 * mat_ABmaster_scale * mat_medium_level * IMG_NORM_PIXEL(mat_spectrum,vec2(0.5,0)).r;
        float treble_value = 0.3 * mat_ABmaster_scale * mat_treble_level * IMG_NORM_PIXEL(mat_spectrum,vec2(0.83,0)).r;
        audio_value += bass_value;
        audio_value += medium_value;
        audio_value += treble_value;

        // Time var for fixed rate (steady)
        float fx_param_time = fract(mat_param_time_source - mat_param_offset);

        if (fx_param_time < mat_param_decay) {
            fx_param_time = 1;
        } else {
            // get back a value from 0-1 (from end of decay to 1 - end of beat)
            fx_param_time = (fx_param_time - mat_param_decay) * 1 / (1 - mat_param_decay);
            if (fx_param_time < mat_param_release) {
                fx_param_time = 1 - fx_param_time * 1 / mat_param_release;
            } else {
                fx_param_time = 0;
            }
        }

        #if defined(mat_param_move_IS_Fixed_Rate)
            modulated_amount =  fx_param_time * amount;
        #elif defined(mat_param_move_IS_Fixed_Rate_With_Audio)
            modulated_amount =  fx_param_time *  audio_value * amount;
        #elif defined(mat_param_move_IS_Fixed_Rate_With_Bass_Audio)
            modulated_amount =  fx_param_time * bass_value * 3 * amount;
        #elif defined(mat_param_move_IS_Fixed_Rate_With_Treble_Audio)
            modulated_amount =  fx_param_time * treble_value * 3 * amount;
        #elif defined(mat_param_move_IS_Audio)
            modulated_amount =  audio_value * amount * 5;
            modulated_amount *= 0.1;
        #elif defined(mat_param_move_type_IS_Bass_Audio)
            modulated_amount =  bass_value * 3 * amount * 5;
            modulated_amount *= 0.1;
        // #elif defined(mat_param_move_type_IS_Treble_Audio)
        #else
            modulated_amount =  treble_value * 3 * amount * 5;
            modulated_amount *= 0.1;
        #endif

        modulated_amount = clamp(modulated_amount, mat_param_floor * amount, amount);
    } else {
		  // Manual
        modulated_amount = amount;
    }

    #if defined(mat_transition_IS_CrossZoom)
		out_color = CrossZoomTransition(uv, modulated_amount);
    #elif defined(mat_transition_IS_Hexagons)
		out_color = HexagonalizeTransition(uv, modulated_amount);
    #elif defined(mat_transition_IS_ButterflyWaves)
		out_color = ButterflyTransition(uv, modulated_amount);
    #elif defined(mat_transition_IS_GlitchMemories)
		out_color = GlitchMemoriesTransition(uv, modulated_amount);
    #elif defined(mat_transition_IS_Squares)
		out_color = RANDSquaresTransition(uv, modulated_amount);
    #endif

    return out_color;
}
